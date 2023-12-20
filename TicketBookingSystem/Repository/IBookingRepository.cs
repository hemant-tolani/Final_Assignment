using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Repository
{
    internal interface IBookingRepository
    {

        void AddBooking(Booking newBooking);
        void UpdateBooking(int id, int eid);
        void DeleteBooking(int bookingId);
        List<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);

    }
}
