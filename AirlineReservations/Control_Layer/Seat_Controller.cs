using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class Seat_Controller
    {
        private SeatDBIF seat_db;
        
        // instantiate with the flight that the seat controller controls
        public Seat_Controller()
        {
            seat_db = new SeatDB();
        }

        // get a specific seat
        public Seat GetSeat(string seatID)
        {
            return null;
        }

    }
}