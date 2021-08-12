using System;
using System.Collections.Generic;

#nullable disable

namespace Insurance.Insurance
{
    public partial class VehicleModel
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelType { get; set; }
        public decimal Price { get; set; }
    }
}
