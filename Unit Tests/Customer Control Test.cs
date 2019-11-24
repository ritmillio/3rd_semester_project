using NUnit.Framework;
using AirlineReservations.Control_Layer;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;

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
            var output = this.custController.CreateCustomer("Customer_Test", false);
            Assert.AreEqual(output, SuccessState.Success);
            var newcustomers = custDB.GetAllCustomers();
            Assert.AreEqual(customers.Count,  newcustomers.Count-1); // a new customer has been created
            var cust = newcustomers[0];
            var output2 = this.custController.RemoveCustomer(cust.CustomerID);
            Assert.AreEqual(SuccessState.Success, output2);
            newcustomers = custDB.GetAllCustomers();
            Assert.AreEqual(customers.Count, newcustomers.Count);
        }
    }
}