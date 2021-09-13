using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Persistence
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        [Key]
        public Guid BookingNumber { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int RentalMileage { get; set; }
        public int? ReturnMileage { get; set; }
        public string VehicleId { get; set; }
        public VehicleModel Vehicle { get; set; }
    }
}
