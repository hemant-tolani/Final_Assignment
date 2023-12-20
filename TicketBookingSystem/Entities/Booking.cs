using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Entities
{
    public class Booking
    {
        // Attributes
        public int booking_id { get; set; }
        public int event_id { get; set; }
        public int customer_id { get; set; }
        public int num_tickets { get; set; }
        public decimal total_cost { get; set; }
        public DateTime booking_date { get; set; }

        public Booking()
        {
            
        }

       public Booking(int Booking_id, int Event_id, int Customer_id, int Num_tickets, decimal Total_cost, DateTime Booking_date)
        {
            booking_id = Booking_id;
            event_id = Event_id;
            customer_id = Customer_id;
            num_tickets = Num_tickets;
            total_cost = Total_cost;
            booking_date = Booking_date;
        }


      
    }
}
