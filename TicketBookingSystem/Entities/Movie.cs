//using System;
//using TicketBookingSystem.Entities;

//namespace TicketBookingSystem.Entities
//{
//    public class Movie : Event
//    {
//        // Additional attributes specific to Movie
//        public string Genre { get; set; }
//        public string ActorName { get; set; }
//        public string ActressName { get; set; }

//        // Constructor
//        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, Venue venue,
//                     int totalSeats, decimal ticketPrice, string genre, string actorName, string actressName)
//            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, EventType.Movie)
//        {
//            Genre = genre;
//            ActorName = actorName;
//            ActressName = actressName;
//        }

//        // Implement abstract methods from Event class
//        public override decimal CalculateTotalRevenue()
//        {
//            // Calculate revenue for Movie
//            // Implement logic here
//            return 0; // Placeholder, replace with actual logic
//        }

//        public override void BookTickets(int numTickets)
//        {
//            // Book tickets logic for Movie
//            // Implement logic here
//        }

//        public override void CancelBooking(int numTickets)
//        {
//            // Cancel booking logic for Movie
//            // Implement logic here
//        }
//    }
//}
