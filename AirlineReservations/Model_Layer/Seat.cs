namespace AirlineReservations.Model_Layer{

    public class Seat
    {
        public string SeatId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string FlightId { get; set; }
        public int BookingNo { get; set; }

        public Seat(string type, decimal price, string seatId){
            this.Type = type; 
            this.Price = price;
            this.SeatId = seatId;
        }

        public Seat()
        {
        }

    }

}