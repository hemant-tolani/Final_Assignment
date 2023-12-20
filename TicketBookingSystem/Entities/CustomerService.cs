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
    internal class CustomerService : ICustomerRepository
    {

        public string connectionString;
        SqlCommand cmd = null;

        public CustomerService()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-POVHQKLI;Database=payxpert;Trusted_Connection=True");
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public void Addcustomer(Customer c)
        {


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Customer (customer_id, customer_name, email, phone_number) VALUES (@cid @cname, @cmail, @cphn)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cid", c.customer_id);
                    command.Parameters.AddWithValue("@cname", c.customer_name);
                    command.Parameters.AddWithValue("@cmail", c.email);
                    command.Parameters.AddWithValue("@cphn", c.phone_number);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdateCustomer(string name, int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Customer SET customer_name = @Name WHERE customer_id = @CustomerId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CustomerId", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new Exception("Update operation failed or customer does not exist.");
                    }
                }
            }


        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Customer WHERE customer_id = @CustomerId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new Exception("Delete operation failed or customer does not exist.");
                    }
                }
            }
        }



        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customer";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer newCustomer = new Customer
                            {
                                customer_id = Convert.ToInt32(reader["customer_id"]),
                                customer_name = reader["customer_name"].ToString(),
                                email = reader["email"].ToString(),
                                phone_number = reader["phone_number"].ToString()
                            };

                            customers.Add(newCustomer);
                        }
                    }
                }
            }

            return customers;
        }


        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customer WHERE customer_id = @CustomerId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                customer_id = Convert.ToInt32(reader["customer_id"]),
                                customer_name = reader["customer_name"].ToString(),
                                email = reader["email"].ToString(),
                                phone_number = reader["phone_number"].ToString()
                            };
                        }
                    }
                }
            }

            return customer;
        }












    }
}
    
