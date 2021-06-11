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
        public decimal BaseDayRental { get; set; }
        public decimal KilometerPrice { get; set; }
        public int CurrentMileage { get; set; }
        public bool IsRented { get; set; }
        public VehicleCategoryModel VehicleCategory { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
