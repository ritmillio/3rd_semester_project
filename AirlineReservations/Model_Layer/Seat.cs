namespace AirlineReservations.Model_Layer{

    public class Seat
    {
        private string seatId { get; set; }
        private string type { get; set; }
        private bool isAvailable { get; set; }
        private decimal price { get; set; }
        private string flightId { get; set; }
        private string bookingNo { get; set; }

        public Seat(string type , bool isAvailable , decimal price, string seatId){
            this.type = type; 
            this.isAvailable = isAvailable;
            this.price = price;
            this.seatId = seatId;
        }

        public Seat()
        {
        }

        public string SeatId
        {
            get { return seatId;}
            set { SeatId = value; }
        }

        public string Type{
            get{return type;}
            set{ type = value;}
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set
            {
                isAvailable = value;
            }
        }
        public decimal Price{
            get{return price;}
            set{price = value;}
        }

        public string FlightId
        {
            get { return flightId; }
            set { flightId = value;}
        }

        public string BookingNo
        {
            get { return bookingNo; }
            set { bookingNo = value; }
        }
 

    }

}