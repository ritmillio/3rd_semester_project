using System;
using System.Collections.Generic;
using System.Linq;
using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class ReservationController : ReservationServiceIF
    {
        private IReservationDb _reserveDb;
        private ISeatDb _seatDb;
        public ReservationController()
        {
            this._reserveDb = new ReservationDb();
            this._seatDb = new SeatDb();
        }
        
        // create a new reservation, return booking no. reservations can be created without a referenced customer
        public int NewReservation(List<Seat> seats, int customerId = 1)
        {
            //get the full price of the reservation
            var priceSum = seats.Sum(seat => seat.Price);
            var reservation = new Reservation(priceSum, customerId);
            
            //create the reservation, the database will return a booking number
            var bookingNo = _reserveDb.InsertReservation(reservation, seats);
            
            return bookingNo;
        }

        // delete a current reservation, return success state
        public SuccessState ReleaseReservation(int bookingNo)
        {
            // check if the reservation exists
            return _reserveDb.GetReservationById(bookingNo) == null ? SuccessState.BadInput : _reserveDb.DeleteReservation(bookingNo);
        }
    }
}