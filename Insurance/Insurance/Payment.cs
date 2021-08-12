using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? InsuranceId { get; set; }
        public string Contact { get; set; }
        public decimal PremiumAmount { get; set; }

        public virtual Customer ContactNavigation { get; set; }
        public virtual InsurancePolicy Insurance { get; set; }
    }
}
