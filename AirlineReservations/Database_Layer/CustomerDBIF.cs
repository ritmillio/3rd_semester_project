using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    public interface CustomerDBIF
    {
        SuccessState InsertCustomer(Customer cust);
        Customer GetCustomerById(int customerId);
        SuccessState DeleteCustomer(int customerId);
        SuccessState UpdateCustomer(int customerId, Customer cust);
        List<Customer> GetAllCustomers();
    }
}
