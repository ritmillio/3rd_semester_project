using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    public interface SeatDBIF
    {
        SuccessState InsertSeat(Seat seat);
        Seat GetSeatById(string seatId);
        SuccessState DeleteSeat(string seatId);
        SuccessState UpdateSeat(string seatId, Seat seat);
        ArrayList GetAllSeats();
    }
}
