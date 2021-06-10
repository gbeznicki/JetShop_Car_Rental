using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Persistence
{
    public class VehicleModel
    {
        [Key]
        public string VehicleId { get; set; }
        public int VehicleCategoryId { get; set; }
        public VehicleCategoryModel VehicleCategory { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
