using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class InsurancePolicy
    {
        public InsurancePolicy()
        {
            Claims = new HashSet<Claim>();
            Payments = new HashSet<Payment>();
            TravelInsurances = new HashSet<TravelInsurance>();
            VehicleInsurances = new HashSet<VehicleInsurance>();
        }

        public int InsuranceId { get; set; }
        public string Contact { get; set; }
        public DateTime IssueDate { get; set; }
        public string PolicyType { get; set; }
        public string IsActive { get; set; }

        public virtual Customer ContactNavigation { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TravelInsurance> TravelInsurances { get; set; }
        public virtual ICollection<VehicleInsurance> VehicleInsurances { get; set; }
    }
}
