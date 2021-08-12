using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class TravelModel
    {
        public int TravelId { get; set; }
        public string TravelType { get; set; }
        public int LengthOfStay { get; set; }
        public decimal PricePerPerson { get; set; }
    }
}
