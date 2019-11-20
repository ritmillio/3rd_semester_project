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
        Customer GetCustomerById(string customerId);
        SuccessState DeleteCustomer(string customerId);
        SuccessState UpdateCUstomer(string customerId, Customer cust);
        ArrayList GetAllCustomers();
    }
}
