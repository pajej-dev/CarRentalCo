using System;

namespace CarRentalCo.Orders.Application.Settings
{
    public class RentalCarClientPolicySettings
    {
        public int FailureThreshold { get; set; }
        public TimeSpan DurationOfBreakTimeSpan { get; set; }
        public int Retries { get; set; }
    }
}
