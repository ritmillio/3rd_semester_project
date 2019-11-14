using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface ReservationDBIF
    {
        void InsertReservation(ReservationDBIF reservation);
        ReservationDBIF GetReservationById(int bookingNo);
        void DeleteReservation(int bookingNo);
        void UpdateReservation(int bookingNo, ReservationDBIF reservation);
        List<ReservationDBIF> GetAllReservations();

    }
}
