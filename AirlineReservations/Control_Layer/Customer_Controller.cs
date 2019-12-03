using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class Customer_Controller
    {
        private CustomerDBIF cust_db;
        
        // instantiate db
        public Customer_Controller()
        {
            this.cust_db = new CustomerDB();
        }
        
        // create a new customer
        public int CreateCustomer(string name, bool isAdmin)
        {
            var customer = new Customer(name, isAdmin);
            return cust_db.InsertCustomer(customer);
        }
        
        // remove an existing customer
        public SuccessState RemoveCustomer(int customerID)
        {
            return cust_db.DeleteCustomer(customerID);
        }

    }
}