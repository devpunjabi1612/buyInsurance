using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class Customer
    {
        public Customer()
        {
            Claims = new HashSet<Claim>();
            InsurancePolicies = new HashSet<InsurancePolicy>();
            Payments = new HashSet<Payment>();
            VehicleCustomers = new HashSet<VehicleCustomer>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<VehicleCustomer> VehicleCustomers { get; set; }
    }
}
