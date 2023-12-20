//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TicketBookingSystem.Entities
//{
//    public class BookingSystem
//    {
//        // Attributes
//        private List<Event> _events;

//        // Constructor
//        public BookingSystem()
//        {
//            _events = new List<Event>();
//        }

//        // Method to create a new event
//        public Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats,
//                                 decimal ticketPrice, EventType eventType, Venue venue)
//        {
//            // Create an event and add it to the list of events
//            Event newEvent = new Event(eventName, date, time, venue, totalSeats, ticketPrice, eventType);
//            _events.Add(newEvent);
//            return newEvent;
//        }

//        // Other methods like bookTickets, calculateBookingCost, cancelBooking, getAvailableNoOfTickets, etc.
//        // would be implemented here as per the requirement
//    }
//}
