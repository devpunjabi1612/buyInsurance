using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehicleCustomers = new HashSet<VehicleCustomer>();
        }

        public string Model { get; set; }
        public string VehicleType { get; set; }
        public string Manufacturer { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime PurchasedDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }

        public virtual ICollection<VehicleCustomer> VehicleCustomers { get; set; }
    }
}
