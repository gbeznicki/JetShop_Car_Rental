using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Persistence
{
    public class VehicleModel
    {
        [Key]
        public string VehicleId { get; set; }
        public VehicleCategoryModel CarCategory { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
