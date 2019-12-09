using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class CustomerController
    {
        private ICustomerDb _custDb;
        
        // instantiate db
        public CustomerController()
        {
            this._custDb = new CustomerDb();
        }
        
        // create a new customer
        public int CreateCustomer(string name, bool isAdmin)
        {
            var customer = new Customer(name, isAdmin);
            return _custDb.InsertCustomer(customer);
        }
        
        // remove an existing customer
        public SuccessState RemoveCustomer(int customerId)
        {
            return _custDb.DeleteCustomer(customerId);
        }

    }
}