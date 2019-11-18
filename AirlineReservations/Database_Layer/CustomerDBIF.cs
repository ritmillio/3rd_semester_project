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
        int InsertCustomer(Customer cust);
        CustomerDBIF GetCustomerById(string customerId);
        int DeleteCustomer(string customerId);
        int UpdateCUstomer(string customerId, Customer cust);
        ArrayList GetAllCustomers();
    }
}
