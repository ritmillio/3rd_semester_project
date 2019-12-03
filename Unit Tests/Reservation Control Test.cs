using System;
using System.Collections;
using System.Collections.Generic;
using AirlineReservations.Control_Layer;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;
using NUnit.Framework;

namespace Unit_Tests
{
    [TestFixture]
    public class ReservationControlTest
    {
        private Reservation_Controller reserve_ctr;
        private FlightController flight_ctr;
        private ReservationDBIF reserve_db;
        private SeatDBIF seat_db;
        private ModelDBIF model_db;
        private int test_flight;

        public ReservationControlTest()
        {
            this.reserve_ctr = new Reservation_Controller();
            this.flight_ctr = new FlightController();
            this.reserve_db = new ReservationDB();
            this.model_db = new ModelDB();
            
            DateTime departure = new DateTime(2019, 1, 12, 14, 0, 0);
            DateTime arrival = new DateTime(2019, 1, 12, 12, 30, 0);

            model_db.InsertModel(new Model("reserve_ctr_test", 10));
            this.test_flight = flight_ctr.NewFlight("reserve_ctr_test", departure, arrival);
        }

        // Create and remove a reservation
        [Test]
        public void CreateRemoveReservation()
        {
            var seats = flight_ctr.GetAllSeats(this.test_flight);
            // Reserve all the seats on the plane, don't specify customer
            var reserve_id = reserve_ctr.NewReservation(seats);
            // Check that all the seats on the flight, make sure they all have the correct booking number
            seats = flight_ctr.GetAllSeats(this.test_flight);
            foreach (var seat in seats)
            {
                Assert.AreEqual(reserve_id, seat.BookingNo);
            }

            reserve_ctr.ReleaseReservation(reserve_id);
            
            // Check that every seat on the flight is not reserved
            seats = flight_ctr.GetAllSeats(this.test_flight);
            foreach (var seat in seats)
            {
               Assert.AreEqual(0, seat.BookingNo); 
            }
            
        }
        
        // Create invalid reservations
        [Test]
        public void CreateInvalidReservation()
        {
            var seats = new List<Seat>();
            seats.Add(new Seat("type", 10, "invalidID"));
            var reserve_id = reserve_ctr.NewReservation(seats);
            Assert.AreEqual(0, reserve_id);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            flight_ctr.RemoveFlight(this.test_flight);
            model_db.DeleteModelById("reserve_ctr_test");
        }
    }
}