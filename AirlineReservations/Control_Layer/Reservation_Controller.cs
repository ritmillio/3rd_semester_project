using System.Collections.Generic;

namespace AirlineReservations.Control_Layer
{
    public class Reservation_Controller
    {
        public Reservation_Controller()
        {
        }
        
        // create a new reservation, return booking no.
        public int NewReservation(List<int> seatids, int customer_id)
        {
            return -1;
        }

        // delete a current reservation, return success state
        public int ReleaseReservation(int bookingNo)
        {
            return 0;
        }
    }
}