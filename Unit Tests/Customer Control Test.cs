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
            var cust_id = this.custController.CreateCustomer("Customer_Test", false);
            Assert.Greater(cust_id, -1);
            Assert.NotNull(custDB.GetCustomerById(cust_id));
            var output = this.custController.RemoveCustomer(cust_id);
            Assert.AreEqual(SuccessState.Success, output);
            Assert.IsNull(custDB.GetCustomerById(cust_id));
        }
    }
}