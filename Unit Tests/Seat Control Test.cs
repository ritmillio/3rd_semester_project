using System;
using AirlineReservations.Control_Layer;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Unit_Tests
{
    [TestFixture]
    public class Seat_Control_Test
    {
        private SeatDBIF seat_db;
        private Seat_Controller seat_ctr;
        private object currentFlight;

        /*
        public Seat_Control_Test()
        {
            var flight_ctr = new FlightController();
            var flight_db = new FlightDB();
            flight_ctr.NewFlight("A380", DateTime.Now, DateTime.Now);
            this.currentFlight = flight_db.GetAllFlights()[0];
            
            this.seat_db = new SeatDB();
            this.seat_ctr = new Seat_Controller(new Flight("1", "A380", DateTime.Now, 
                DateTime.Now, "unkown", "unkown"));
        }
        */

        [Test]
        public void ReserveReleaseSeat()
        {
            var seat = new Seat("default", true, 0, "1");
            var cust = new Customer("cust", false, "invalid_cust");
            seat_ctr.ReserveSeat(seat, cust);
            // TODO: The remainder of the test lol
        }
    }
}