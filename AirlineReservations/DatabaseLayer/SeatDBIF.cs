using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface SeatDBIF
    {
        void InsertSeat(Seat seat);
        Seat GetSeatById(string seatId);
        void DeleteSeat(string seatId);
        void UpdateSeat(string seatId, Seat seat);
        List<Seat> GetAllSeats();
    }
}
