using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class Claim
    {
        public int ClaimId { get; set; }
        public int? InsuranceId { get; set; }
        public string Contact { get; set; }
        public string ReasonToClaim { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public string ApprovalStatus { get; set; }
        public decimal AmountInsured { get; set; }

        public virtual Customer ContactNavigation { get; set; }
        public virtual InsurancePolicy Insurance { get; set; }
    }
}
