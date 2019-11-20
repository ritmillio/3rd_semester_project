using NUnit.Framework;
using AirlineReservations.Control_Layer;
using AirlineReservations.DatabaseLayer;

namespace Unit_Tests
{
    [TestFixture]
    public class CustomerControlTest
    {
        private Customer_Controller custController;
        private CustomerDBIF custDB;
        
        public CustomerControlTest()
        {
            this.custController = new Customer_Controller();
            this.custDB = new CustomerDB();
        }
        
        [Test]
        public void CustomerCreateRemoveTest()
        {
            var customers = custDB.GetAllCustomers();
            this.custController.CreateCustomer("Customer_Test", false);
            var newcustomers = custDB.GetAllCustomers();
            Assert.AreEqual(customers.Count,  newcustomers.Count-1); // a new customer has been created
        }
    }
}