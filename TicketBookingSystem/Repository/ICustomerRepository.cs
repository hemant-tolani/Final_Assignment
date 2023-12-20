using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entities;

namespace TicketBookingSystem.Repository
{
    internal interface ICustomerRepository
    {

        void Addcustomer(Customer c);

        void UpdateCustomer(string name, int id);

        void DeleteCustomer(int customerId);

        List<Customer> GetAllCustomers();

        Customer GetCustomerById(int customerId);

    }
}
