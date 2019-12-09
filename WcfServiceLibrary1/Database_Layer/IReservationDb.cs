using System.Collections;
using System.Collections.Generic;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public interface IReservationDb
    {
        int InsertReservation(Reservation reservation, List<string> seatIds);
        Reservation GetReservationById(int bookingNo);
        SuccessState DeleteReservation(int bookingNo);
        SuccessState UpdateReservation(int bookingNo, Reservation reservation);
        List<Reservation> GetAllReservations();

    }
}
