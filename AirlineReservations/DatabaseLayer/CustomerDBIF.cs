using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface CustomerDBIF
    {
        void InsertCustomer(CustomerDBIF cust);
        CustomerDBIF GetCustomerById(string customerId);
        void DeleteCustomer(string customerId);
        void UpdateCUstomer(string customerId, CustomerDBIF cust);
        List<CustomerDBIF> GetAllCustomers();
    }
}
