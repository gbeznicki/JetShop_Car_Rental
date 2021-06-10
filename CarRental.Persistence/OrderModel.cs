using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Persistence
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public Guid BookingNumber { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentalDate { get; set; }
        public VehicleModel Vehicle { get; set; }
        public int CurrentMileage { get; set; }
    }
}
