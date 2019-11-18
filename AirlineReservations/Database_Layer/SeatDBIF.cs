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
        int InsertSeat(Seat seat);
        Seat GetSeatById(string seatId);
        int DeleteSeat(string seatId);
        int UpdateSeat(string seatId, Seat seat);
        ArrayList GetAllSeats();
    }
}
