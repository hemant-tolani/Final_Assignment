using System;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Entities
{
    //public enum EventType
    //{
    //    Movie,
    //    Sports,
    //    Concert
    //}

    public class Event
    {
        // Attributes
        public int event_id { get; set; }
        public string event_name { get; set; }
        public DateTime event_date { get; set; }
        public TimeSpan event_time { get; set; }
        public int venue_id { get; set; }
        public int total_seats { get; set; }
        public int available_seats { get; set; }
        public decimal ticket_price { get; set; }
        public string event_type { get; set; }

        // Constructors
        public Event()
        {
            // Default constructor
        }

        public Event(int id, string eventName, DateTime eventDate, TimeSpan eventTime, int venue,
                        int totalSeats, int availableseats ,decimal ticketPrice, string eventType)
        {
            event_id = id;
            event_name = eventName;
            event_date = eventDate;
            event_time = eventTime;
            venue_id = venue;
            total_seats = totalSeats;
            available_seats = availableseats; 
            ticket_price = ticketPrice;
            event_type = eventType;
        }

        
    }
}
