using Polly;
using Polly.Wrap;
using System.Net.Http;

namespace CarRentalCo.Orders.Infrastructure.Policies
{
    public interface IRentalCarClientPolicy
    {
        public AsyncPolicyWrap<HttpResponseMessage> Policy { get; }
    }
}
