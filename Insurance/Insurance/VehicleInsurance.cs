using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class VehicleInsurance
    {
        public string VehicleType { get; set; }
        public string PlanType { get; set; }
        public int Duration { get; set; }
        public string VehiclePolicyNumber { get; set; }
        public int? InsuranceId { get; set; }

        public virtual InsurancePolicy Insurance { get; set; }
    }
}
