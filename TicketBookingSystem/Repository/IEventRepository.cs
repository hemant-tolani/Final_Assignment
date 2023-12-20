using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Repository
{
   

        public interface IEventRepository
        {
            Event GetEventById(int eventId);
            List<Event> GetAllEvents();
            public void AddEvent(Event e);
            void UpdateEvent(int id, string status);
            void DeleteEvent(int eventId);
        }

    }

