using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface ReservationDBIF
    {
        int InsertReservation(Reservation reservation);
        Reservation GetReservationById(int bookingNo);
        int DeleteReservation(int bookingNo);
        int UpdateReservation(int bookingNo, Reservation reservation);
        ArrayList GetAllReservations();

    }
}
