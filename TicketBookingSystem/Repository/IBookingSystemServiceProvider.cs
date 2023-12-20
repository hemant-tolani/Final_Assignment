using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Repository
{
    public interface IBookingSystemServiceProvider
    {
        decimal CalculateBookingCost(int numTickets);

        void BookTickets(string eventName, int numTickets, Customer[] arrayOfCustomer);

        void CancelBooking(int bookingId);

        Booking GetBookingDetails(int bookingId);
    }
}
