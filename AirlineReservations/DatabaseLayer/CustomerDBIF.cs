﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface Customer
    {
        void InsertCustomer(Customer cust);
        Customer GetCustomerById(string customerId);
        void DeleteCustomer(string customerId);
        void UpdateCUstomer(string customerId, Customer cust);
        List<Customer> GetAllCustomers();
    }
}
