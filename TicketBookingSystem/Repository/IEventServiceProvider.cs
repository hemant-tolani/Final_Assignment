using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Repository
{
    public interface IEventServiceProvider
    {
        Event CreateEvent(string eventName, string date, string time, int totalSeats,
                          decimal ticketPrice, string eventType, Venue venue);

        List<string> GetEventDetails();

        int GetAvailableNoOfTickets();
    }
}
