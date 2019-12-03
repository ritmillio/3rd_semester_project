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
        private Seat_Controller seat_ctr;

        public Seat_Control_Test()
        {
            this.seat_ctr = new Seat_Controller();

        }
/*
        [Test]
        public void ReserveReleaseSeat()
        {
            var seat = new Seat("default", true, 0, "1");
            var cust = new Customer("cust", false);
            seat_ctr.ReserveSeat(seat, cust);
            // TODO: The remainder of the test lol
    
        }*/
    }
    
}