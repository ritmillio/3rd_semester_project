using System.Collections.Generic;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public interface ICustomerDb
    {
        int InsertCustomer(Customer cust);
        Customer GetCustomerById(int customerId);
        SuccessState DeleteCustomer(int customerId);
        SuccessState UpdateCustomer(int customerId, Customer cust);
        List<Customer> GetAllCustomers();
    }
}
