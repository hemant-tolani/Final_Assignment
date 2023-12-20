using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Repository;
using TicketBookingSystem.Utility;

namespace TicketBookingSystem.Entities
{
    public class EventService : IEventRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        public EventService() {
            //sqlConnection = new SqlConnection("Server=LAPTOP-POVHQKLI;Database=payxpert;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public void AddEvent(Event newEvent)
        {


            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string query = @"INSERT INTO Venue (venue_id, venue_name, address) VALUES (@vid @vtName, @vad)";

            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@vid", venue.venue_id);
            //        command.Parameters.AddWithValue("@vtName", venue.venue_name);
            //        command.Parameters.AddWithValue("@vad", venue.address);

            //        command.ExecuteNonQuery();
            //    }
            //}





            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Event (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type)
                         VALUES (@Eventid @EventName, @EventDate, @EventTime, @VenueId, @TotalSeats, @AvailableSeats, @TicketPrice, @EventType)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Eventid", newEvent.event_id);
                    command.Parameters.AddWithValue("@EventName", newEvent.event_name);
                    command.Parameters.AddWithValue("@EventDate", newEvent.event_date);
                    command.Parameters.AddWithValue("@EventTime", newEvent.event_time);
                    command.Parameters.AddWithValue("@VenueId", newEvent.venue_id);
                    command.Parameters.AddWithValue("@TotalSeats", newEvent.total_seats);
                    command.Parameters.AddWithValue("@AvailableSeats", newEvent.available_seats);
                    command.Parameters.AddWithValue("@TicketPrice", newEvent.ticket_price);
                    command.Parameters.AddWithValue("@EventType", newEvent.event_type);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdateEvent(int id, string status)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Event
                         SET event_name = @Event
                         WHERE event_id = @EventId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", id);
                    command.Parameters.AddWithValue("@Event", status);
                    command.ExecuteNonQuery();
                }
            }
        }



        public void DeleteEvent(int eventId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"DELETE FROM Event WHERE event_id = @EventId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Event";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event newEvent = new Event
                            {
                                event_id = Convert.ToInt32(reader["event_id"]),
                                event_name = reader["event_name"].ToString(),
                                event_date = Convert.ToDateTime(reader["event_date"]),
                                event_time = TimeSpan.Parse(reader["event_time"].ToString()),
                            };

                            events.Add(newEvent);
                        }
                    }
                }
            }

            return events;
        }
    



        public Event GetEventById(int eventId)
        {
            Event foundEvent = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Event WHERE event_id = @EventId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foundEvent = new Event
                            {
                                event_id = Convert.ToInt32(reader["event_id"]),
                                event_name = reader["event_name"].ToString(),
                                event_date = Convert.ToDateTime(reader["event_date"]),
                                event_time = TimeSpan.Parse(reader["event_time"].ToString()),
                            };
                        }
                    }
                }
            }

            return foundEvent;
        }








    }
}
