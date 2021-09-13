using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Persistence
{
    public class VehicleCategoryModel
    {
        [Key]
        public int VehicleCategoryId { get; set; }
        public string VehicleCategoryName { get; set; }
        public List<VehicleModel> Vehicles { get; set; }
    }
}