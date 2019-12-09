using System;
using System.Collections.Generic;
using System.Linq;
using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class Reservation_Controller : ReservationServiceIF
    {
        private IReservationDb _reserveDb;
        private ISeatDb _seatDb;
        public Reservation_Controller()
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
            var seatIds = seats.Select(seat => seat.SeatId).ToList();
            
            //create the reservation, the database will return a booking number
            var bookingNo = _reserveDb.InsertReservation(reservation, seatIds);
            
            return bookingNo;
        }

        // delete a current reservation, return success state
        public SuccessState ReleaseReservation(int bookingNo)
        {
            // check if the reservation exists
            if (_reserveDb.GetReservationById(bookingNo) == null)
            {
                return SuccessState.BadInput;
            }
            
            var seats = _seatDb.GetSeatByBookingNo(bookingNo);
            foreach (var seat in seats)
            {
                _seatDb.UpdateSeat(seat.SeatId, seat, true);
            }

            return _reserveDb.DeleteReservation(bookingNo);
        }
    }
}