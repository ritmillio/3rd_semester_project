using System;
using NUnit.Framework;
using AirlineReservations.Control_Layer;
using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;
using NUnit.Framework.Internal.Execution;

namespace Unit_Tests
{
    [TestFixture]
    public class FlightControlTests
    {
        private FlightController _flightControl;
        private IFlightDb _flightDb;
        private IModelDb _modelDb;
        private DateTime _departDefault;
        private DateTime _arriveDefault;
        
        public FlightControlTests()
        {
            this._flightControl = new FlightController();
            this._flightDb = new FlightDb();
            this._modelDb = new ModelDb();

            // temporary test model
            _modelDb.InsertModel(new Model("flight_ctr_test", 100));
            this._departDefault = new DateTime(2019, 1, 12, 12, 30, 0);
            this._arriveDefault = new DateTime(2019, 1, 12, 14, 0, 0);
        }
        
        [Test]
        public void CreateRemoveValidFlight()
        {
            var flightId = this._flightControl.NewFlight("flight_ctr_test", 
                this._departDefault, this._arriveDefault);
            Assert.Greater(flightId, -1);
            Flight newflight = _flightDb.GetFlightById(flightId);
            Assert.NotNull(newflight);
            var output = _flightControl.RemoveFlight(newflight.FlightNo);
            Assert.AreEqual(SuccessState.Success, output);
            newflight = _flightDb.GetFlightById(flightId);
            Assert.IsNull(newflight);
        }

        [Test]
        public void CreateInvalidFlight()
        {
            var flights = _flightDb.GetAllFlights();
            var output = this._flightControl.NewFlight("this_model_should_not_exist",
                this._departDefault, this._arriveDefault);
            Assert.AreEqual(-1, output);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            // Assume that if it was successfully added, it can be removed
            this._modelDb.DeleteModelById("flight_ctr_test");
        }
    }
}