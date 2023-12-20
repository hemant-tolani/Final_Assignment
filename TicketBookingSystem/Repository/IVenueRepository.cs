using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Repository
{
    public interface IVenueRepository
    {

        public void AddVenue(Venue venue);
        void UpdateVenue(Venue updatedVenue);
        void DeleteVenue(int venueId);
        List<Venue> GetAllVenues();
        Venue GetVenueById(int venueId);
    }
}
