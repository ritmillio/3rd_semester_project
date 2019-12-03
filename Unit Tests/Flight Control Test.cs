using System;
using NUnit.Framework;
using AirlineReservations.Control_Layer;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;
using NUnit.Framework.Internal.Execution;

namespace Unit_Tests
{
    [TestFixture]
    public class Flight_Control_Tests
    {
        private FlightController flight_control;
        private FlightDBIF flight_db;
        private DateTime depart_default;
        private DateTime arrive_default;
        
        public Flight_Control_Tests()
        {
            this.flight_control = new FlightController();
            this.flight_db = new FlightDB();

            this.depart_default = new DateTime(2019, 1, 12, 12, 30, 0);
            this.arrive_default = new DateTime(2019, 1, 12, 14, 0, 0);
        }
        
        [Test]
        public void CreateRemoveValidFlight()
        {
            var flight_id = this.flight_control.NewFlight("A380", 
                this.depart_default, this.arrive_default);
            Assert.Greater(flight_id, -1);
            Flight newflight = flight_db.GetFlightById(flight_id);
            Assert.NotNull(newflight);
            var output = flight_control.RemoveFlight(newflight.FlightNo);
            Assert.AreEqual(SuccessState.Success, output);
            newflight = flight_db.GetFlightById(flight_id);
            Assert.IsNull(newflight);
        }

        [Test]
        public void CreateInvalidFlight()
        {
            var flights = flight_db.GetAllFlights();
            var output = this.flight_control.NewFlight("this_model_should_not_exist",
                this.depart_default, this.arrive_default);
            Assert.AreEqual(-1, output);
        }
    }
}