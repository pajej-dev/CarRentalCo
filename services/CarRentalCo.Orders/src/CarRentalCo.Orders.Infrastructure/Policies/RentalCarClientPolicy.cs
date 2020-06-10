using CarRentalCo.Orders.Application.Settings;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Net;
using System.Net.Http;

namespace CarRentalCo.Orders.Infrastructure.Policies
{
    public class RentalCarClientPolicy : IRentalCarClientPolicy
    {
        private AsyncPolicyWrap<HttpResponseMessage> policy;
        private readonly RentalCarClientPolicySettings options;
        private readonly ILogger<RentalCarClientPolicy> logger;

        public AsyncPolicyWrap<HttpResponseMessage> Policy => policy;

        public RentalCarClientPolicy(RentalCarClientPolicySettings options, ILoggerFactory loggerFactory)
        {
            this.options = options;
            this.logger = loggerFactory.CreateLogger<RentalCarClientPolicy>();

            var retry = BuildRetryPolicy(options);
            policy = retry.WrapAsync(BuildCircuitBreakerPolicy(options));
        }

        private AsyncCircuitBreakerPolicy<HttpResponseMessage> BuildCircuitBreakerPolicy(RentalCarClientPolicySettings policyOptions)
            => Polly.Policy
             .Handle<Exception>(exception =>
             {
                 return true;
             })
            .OrResult<HttpResponseMessage>(message =>
            {
                if (message.StatusCode == HttpStatusCode.RequestTimeout
                    || message.StatusCode == HttpStatusCode.InternalServerError
                    || message.StatusCode == HttpStatusCode.BadGateway
                    || message.StatusCode == HttpStatusCode.ServiceUnavailable
                    || message.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    return true;
                }

                return false;
            })
            .CircuitBreakerAsync(policyOptions.FailureThreshold, policyOptions.DurationOfBreakTimeSpan,
                onBreak: (del, ts) =>
                {
                    this.logger.LogCritical($"Circuit breaker is now in Open state. Failure Threshold exceeded in circuit breaker. Rejecting requests for: {ts.TotalMilliseconds}ms.");
                },
                onReset: () => this.logger.LogInformation("Circuit breaker is now in Closed state."),
                onHalfOpen: () => this.logger.LogInformation("Circuit breaker is now in Half Open state."));

        private AsyncRetryPolicy<HttpResponseMessage> BuildRetryPolicy(RentalCarClientPolicySettings policyOptions)
            => Polly.Policy
             .Handle<Exception>(exception =>
             {
                 if (exception is BrokenCircuitException)
                 {
                     this.logger.LogWarning("Cannot retry when circuit breaker is opened");
                     return false;
                 }

                 return true;
             })
            .OrResult<HttpResponseMessage>(message =>
            {
                if (message.StatusCode == HttpStatusCode.RequestTimeout
                    || message.StatusCode == HttpStatusCode.InternalServerError
                    || message.StatusCode == HttpStatusCode.BadGateway
                    || message.StatusCode == HttpStatusCode.ServiceUnavailable
                    || message.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    return true;
                }
                return false;
            })
            .WaitAndRetryAsync(policyOptions.Retries,
                retryNumber => TimeSpan.FromMilliseconds(300 * retryNumber),
                onRetry: (del, ts) =>
                {
                    if (del.Exception != default)
                    {
                        logger.LogError(del.Exception, $"An error occured while sending request. Trying to retry in: {ts.TotalMilliseconds}ms");
                    }
                    else if (del.Result != default)
                    {
                        logger.LogError($"Response was not successful. Trying to retry in: {ts.TotalMilliseconds}ms");
                    }
                });
    
    }
}
