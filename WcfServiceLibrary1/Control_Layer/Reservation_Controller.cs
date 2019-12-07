using System;
using System.Collections.Generic;
using System.Linq;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class Reservation_Controller : ReservationServiceIF
    {
        private ReservationDBIF reserve_db;
        private SeatDBIF seat_db;
        public Reservation_Controller()
        {
            this.reserve_db = new ReservationDB();
            this.seat_db = new SeatDB();
        }
        
        // create a new reservation, return booking no. reservations can be created without a referenced customer
        public int NewReservation(List<Seat> seats, int customer_id = 1)
        {
            //get the full price of the reservation
            decimal price_sum = seats.Sum(seat => seat.Price);
            var reservation = new Reservation(price_sum, customer_id);
            List<string> seat_ids = seats.Select(seat => seat.SeatId).ToList();
            
            //ugly way to check if all the seats are valid before updating anything
            foreach (var seat_id in seat_ids)
            {
                var seat = seat_db.GetSeatById(seat_id);
                if (seat == null)
                {
                    Console.WriteLine(seat_id);
                    return 0;
                }
            }           
             
            //create the reservation, the database will return a booking number
            var bookingNo = reserve_db.InsertReservation(reservation);
            Console.WriteLine(bookingNo);

            //update every seat with the correct booking number
            foreach (var seat_id in seat_ids)
            {
                var seat = seat_db.GetSeatById(seat_id);
                seat.BookingNo = bookingNo;
                seat_db.UpdateSeat(seat_id, seat);
            }
            
            return bookingNo;
        }

        // delete a current reservation, return success state
        public SuccessState ReleaseReservation(int bookingNo)
        {
            // check if the reservation exists
            if (reserve_db.GetReservationById(bookingNo) == null)
            {
                return SuccessState.BadInput;
            }
            
            var seats = seat_db.GetSeatByBookingNo(bookingNo);
            foreach (var seat in seats)
            {
                seat_db.UpdateSeat(seat.SeatId, seat, true);
            }

            return reserve_db.DeleteReservation(bookingNo);
        }
    }
}