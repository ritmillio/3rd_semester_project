using System;
using System.Collections;
using System.Collections.Generic;
using AirlineReservations.Control_Layer;
using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;
using NUnit.Framework;

namespace Unit_Tests
{
    [TestFixture]
    public class ReservationControlTest
    {
        private ReservationController _reserveCtr;
        private FlightController _flightCtr;
        private IReservationDb _reserveDb;
        private ISeatDb _seatDb;
        private IModelDb _modelDb;
        private int _testFlight;

        public ReservationControlTest()
        {
            this._seatDb = new SeatDb();
            this._reserveCtr = new ReservationController();
            this._flightCtr = new FlightController();
            this._reserveDb = new ReservationDb();
            this._modelDb = new ModelDb();
            
            DateTime departure = new DateTime(2019, 1, 12, 14, 0, 0);
            DateTime arrival = new DateTime(2019, 1, 12, 12, 30, 0);

            //_modelDb.InsertModel(new Model("reserve_ctr_test", 10));
            this._testFlight = _flightCtr.NewFlight("reserve_ctr_test", departure, arrival);
        }

        // Create and remove a reservation
        [Test]
        public void CreateRemoveReservation()
        {
            var seats = _flightCtr.GetAllSeats(this._testFlight);
            // Reserve all the seats on the plane, don't specify customer
            var reserveId = _reserveCtr.NewReservation(seats);
            // Check that all the seats on the flight, make sure they all have the correct booking number
            seats = _flightCtr.GetAllSeats(this._testFlight);
            foreach (var seat in seats)
            {
                Assert.AreEqual(reserveId, seat.BookingNo);
            }

            _reserveCtr.ReleaseReservation(reserveId);
            
            // Check that every seat on the flight is not reserved
            seats = _flightCtr.GetAllSeats(this._testFlight);
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
            // Add 1 valid seat
            seats.Add(_seatDb.GetAllSeatsByFlight(_testFlight)[0]);
            seats.Add(new Seat("type", 10, "invalidID"));
            var reserveId = _reserveCtr.NewReservation(seats);
            Assert.AreEqual(0, reserveId);

            var checkSeat = _seatDb.GetSeatById(seats[0].SeatId);
            Assert.AreEqual(0, checkSeat.BookingNo);
        }

        [Test]
        public void ReserveReservedSeats()
        {
            var seats = _seatDb.GetSeatByBookingNo(6);
            var output = _reserveCtr.NewReservation(seats);
            Assert.AreEqual(0, output);
        }

        [Test]
        public void ReserveOneReservedSeatFourAvailable()
        {
            var seats = _seatDb.GetSeatByBookingNo(6);
            decimal deci = (decimal)50.00;
            seats.Add(new Seat("default", deci, "2.17"));
            var output = _reserveCtr.NewReservation(seats);
            Assert.AreEqual(0, output);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _flightCtr.RemoveFlight(this._testFlight);
            _modelDb.DeleteModelById("reserve_ctr_test");
        }
    }
}