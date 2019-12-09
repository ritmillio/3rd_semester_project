using System.Collections.Generic;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public interface ISeatDb
    {
        SuccessState InsertSeat(Seat seat);
        Seat GetSeatById(string seatId);
        SuccessState DeleteSeat(string seatId);
        SuccessState DeleteSeatByFlightId(int flightId);
        SuccessState UpdateSeat(string seatId, Seat seat, bool remove=false);
        List<Seat> GetAllSeatsByFlight(int flightId);
        List<Seat> GetSeatByBookingNo(int bookingNo);
        SuccessState InsertMultipleSeats(int numberOfSeats, int flightId, string seatType, double price);
    }
}
