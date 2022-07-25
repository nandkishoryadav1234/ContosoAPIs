using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoBookingApi.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public int TotalTickets { get; set; }
        public double TotalCost { get; set; }
        public DateTime BookingDate { get; set; }
        //public virtual Event Event { get; set; }
    }

}