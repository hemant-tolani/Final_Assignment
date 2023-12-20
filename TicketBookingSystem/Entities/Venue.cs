using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Entities
{
    public class Venue
    {
        public int venue_id {  get; set; }


        public string venue_name { get; set; }
        public string address { get; set; }

        public Venue()
        {
        }

       public Venue(int id, string name, string add)
        {
            venue_id = id;
            venue_name = name;
            address = add;
        }
    }
}
