using System;
using NUnit.Framework;
using AirlineReservations.Control_Layer;
using AirlineReservations.Model_Layer;

namespace Unit_Tests
{
    [TestFixture]
    public class Tests
    {
        private FlightController flight_control;
        public Tests()
        {
            this.flight_control = new FlightController();
        }
        
        [Test]
        public void CreateValidFlight()
        {
            int output = this.flight_control.NewFlight("default");
            Assert.AreEqual(output, 0);
            //TODO: missing database reinforcement lookup
        }

        [Test]
        public void CreateInvalidFlight()
        {
            int output = this.flight_control.NewFlight("this_model_should_not_exist");
            Assert.AreEqual(output, 1);
            //TODO: missing database reinforcement lookup
        }
    }
}