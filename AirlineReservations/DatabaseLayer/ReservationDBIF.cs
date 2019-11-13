using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface Reservation
    {
        void InsertReservation(Reservation reservation);
        Reservation GetReservationById(int bookingNo);
        void DeleteReservation(int bookingNo);
        void UpdateReservation(int bookingNo, Reservation reservation);
        List<Reservation> GetAllReservations();

    }
}
