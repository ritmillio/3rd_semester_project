using System;
using AirlineReservations.Control_Layer;
using AirlineReservations.DatabaseLayer;
using NUnit.Framework;

namespace Unit_Tests
{
    [TestFixture]
    public class ReservationControlTest
    {
        private Reservation_Controller reserve_ctr;
        private ReservationDBIF reserve_db;

        public ReservationControlTest()
        {
            this.reserve_ctr = new Reservation_Controller();
            this.reserve_db = new ReservationDB();
        }

        /*
        // Create and remove a reservation
        [Test]
        public void CreateRemoveReservation()
        {
            var reserve_id = reserve_ctr.NewReservation();
            Assert.IsNotNull(reserve_db.GetReservationById(reserve_id));
            var state = reserve_ctr.ReleaseReservation(reserve_id);
            Assert.Equals(state, 0);
            Assert.Null(reserve_db.GetReservationById(reserve_id));
        }
        
        // Create invalid reservations
        [Test]
        public void CreateInvalidReservation()
        {
            var reserve_id = reserve_ctr.NewReservation(80);
            Assert.Equals(reserve_id, 0);
            var reserve_id2 = reserve_ctr.NewReservation(1000); // book too many seats
            Assert.Equals(reserve_id2, 0);
        }
    
        */
    }
}