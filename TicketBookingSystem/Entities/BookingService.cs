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
    internal class BookingService : IBookingRepository
    {


        public string connectionString;
        SqlCommand cmd = null;

        public BookingService()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-POVHQKLI;Database=payxpert;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public void AddBooking(Booking newBooking)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Booking (booking_id, event_id, customer_id, num_tickets, total_cost, booking_date) VALUES (@Bookingid ,@EventId, @CustomerId, @NumTickets, @TotalCost, @BookingDate)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Bookingid", newBooking.booking_id);
                    command.Parameters.AddWithValue("@EventId", newBooking.event_id);
                    command.Parameters.AddWithValue("@CustomerId", newBooking.customer_id);
                    command.Parameters.AddWithValue("@NumTickets", newBooking.num_tickets);
                    command.Parameters.AddWithValue("@TotalCost", newBooking.total_cost);
                    command.Parameters.AddWithValue("@BookingDate", newBooking.booking_date);

                   
                }
            }
        }


        public void UpdateBooking(int id, int eid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Booking SET event_id = @EventId WHERE booking_id = @BookingId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", id);
                    command.Parameters.AddWithValue("@EventId", eid);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBooking(int bookingId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Booking WHERE booking_id = @BookingId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", bookingId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Booking";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking newBooking = new Booking
                            {
                                booking_id = Convert.ToInt32(reader["booking_id"]),
                                event_id = Convert.ToInt32(reader["event_id"]),
                                customer_id = Convert.ToInt32(reader["customer_id"]),
                                num_tickets = Convert.ToInt32(reader["num_tickets"]),
                                total_cost = Convert.ToDecimal(reader["total_cost"]),
                                booking_date = Convert.ToDateTime(reader["booking_date"])
                            };

                            bookings.Add(newBooking);
                        }
                    }
                }
            }

            return bookings;
        }



        public Booking GetBookingById(int bookingId)
        {
            Booking booking = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Booking WHERE booking_id = @BookingId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", bookingId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new Booking
                            {
                                booking_id = Convert.ToInt32(reader["booking_id"]),
                                event_id = Convert.ToInt32(reader["event_id"]),
                                customer_id = Convert.ToInt32(reader["customer_id"]),
                                num_tickets = Convert.ToInt32(reader["num_tickets"]),
                                total_cost = Convert.ToDecimal(reader["total_cost"]),
                                booking_date = Convert.ToDateTime(reader["booking_date"])
                            };
                        }
                    }
                }
            }

            return booking;
        }


    }
}
