
using System.Data.SqlClient;
using TicketBookingSystem.Repository;
using TicketBookingSystem.Utility;

namespace TicketBookingSystem.Entities
{
    public class VenueService : IVenueRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        public VenueService()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-POVHQKLI;Database=payxpert;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public void AddVenue(Venue venue)
        {


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Venue (venue_id, venue_name, address) VALUES (@vid @vtName, @vad)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@vid", venue.venue_id);
                    command.Parameters.AddWithValue("@vtName", venue.venue_name);
                    command.Parameters.AddWithValue("@vad", venue.address);

                    command.ExecuteNonQuery();
                }
            }

        }


        public void UpdateVenue(Venue updatedVenue)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Venue SET venue_name = @VenueName, address = @Address WHERE venue_id = @VenueId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VenueId", updatedVenue.venue_id);
                    command.Parameters.AddWithValue("@VenueName", updatedVenue.venue_name);
                    command.Parameters.AddWithValue("@Address", updatedVenue.address);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteVenue(int venueId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Venue WHERE venue_id = @VenueId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VenueId", venueId);
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Venue> GetAllVenues()
        {
            List<Venue> venues = new List<Venue>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Venue";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venue venue = new Venue
                            {
                                venue_id = Convert.ToInt32(reader["venue_id"]),
                                venue_name = reader["venue_name"].ToString(),
                                address = reader["address"].ToString()
                                // Add other properties as needed
                            };

                            venues.Add(venue);
                        }
                    }
                }
            }

            return venues;
        }


        public Venue GetVenueById(int venueId)
        {
            Venue venue = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Venue WHERE venue_id = @VenueId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VenueId", venueId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venue = new Venue
                            {
                                venue_id = Convert.ToInt32(reader["venue_id"]),
                                venue_name = reader["venue_name"].ToString(),
                                address = reader["address"].ToString()
                                // Add other properties here based on your Venue class
                            };
                        }
                    }
                }
            }

            return venue;
        }

    }
}

