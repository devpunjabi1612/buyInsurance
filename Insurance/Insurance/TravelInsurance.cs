using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class TravelInsurance
    {
        public string TravelType { get; set; }
        public string TravelMode { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PolicyType { get; set; }
        public string TravelPolicyNumber { get; set; }
        public int? InsuranceId { get; set; }

        public virtual InsurancePolicy Insurance { get; set; }
    }
}
