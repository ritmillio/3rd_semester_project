using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    public interface ReservationDBIF
    {
        SuccessState InsertReservation(Reservation reservation);
        Reservation GetReservationById(int bookingNo);
        SuccessState DeleteReservation(int bookingNo);
        SuccessState UpdateReservation(int bookingNo, Reservation reservation);
        ArrayList GetAllReservations();

    }
}
