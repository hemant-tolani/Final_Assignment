namespace TicketBookingSystem.Entities
{
    public class Customer
    {
        // Attributes

        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }

        // Constructors
        public Customer()
        {
            // Default constructor
        }

        public Customer(int id, string customerName, string mail, string phoneNumber)
        {
            customer_id = id;
            customer_name = customerName;
            email = mail;
            phone_number = phoneNumber;
        }

       
    }
}
