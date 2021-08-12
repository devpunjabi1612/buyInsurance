using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class VehicleCustomer
    {
        public int VCid { get; set; }
        public string Contact { get; set; }
        public string RegistrationNumber { get; set; }

        public virtual Customer ContactNavigation { get; set; }
        public virtual Vehicle RegistrationNumberNavigation { get; set; }
    }
}
