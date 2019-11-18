using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class Seat_Controller
    {
        private Flight currentFlight;
        
        // instantiate with the flight that the seat controller controls
        public Seat_Controller(Flight currentFlight)
        {
            this.currentFlight = currentFlight;
        }

        // reserves a given seat for a given customer
        public int ReserveSeat(Seat seat, Customer customer)
        {
            return 0;
        }

        public Seat GetSeat(string seatID)
        {
            return new Seat("", 0); // stub
        }
        
        // releases a seat to be open for reservation
        public int CancelSeat(Seat seat)
        {
            return 0;
        }
    }
}