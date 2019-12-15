using System.Collections.Generic;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public interface ISeatDb
    {
        SuccessState InsertSeat(Seat seat);
        Seat GetSeatById(string seatId, SqlConnection con = null);
        SuccessState DeleteSeat(string seatId);
        SuccessState DeleteSeatByFlightId(int flightId, SqlConnection con = null);
        SuccessState UpdateSeat(Seat seat, bool remove = false, SqlConnection con = null);
        List<Seat> GetAllSeatsByFlight(int flightId);
        List<Seat> GetSeatByBookingNo(int bookingNo);
        SuccessState InsertMultipleSeats(int numberOfSeats, int flightId, string seatType, double price, SqlConnection con = null);
    }
}
