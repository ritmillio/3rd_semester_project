using System;
using NUnit.Framework;
using AirlineReservations.Control_Layer;
using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;

namespace Unit_Tests
{
    [TestFixture]
    public class CustomerControlTest
    {
        private CustomerController _custController;
        private ICustomerDb _custDb;
        
        public CustomerControlTest()
        {
            this._custController = new CustomerController();
            this._custDb = new CustomerDb();
        }
        
        [Test]
        public void CustomerCreateRemoveTest()
        {
            var custId = this._custController.CreateCustomer("Customer_Test", false);
            Assert.Greater(custId, 1);
            Assert.NotNull(_custDb.GetCustomerById(custId));
            Console.WriteLine(custId);
            var output = this._custController.RemoveCustomer(custId);
            Assert.AreEqual(SuccessState.Success, output);
            Assert.IsNull(_custDb.GetCustomerById(custId));
        }
    }
}