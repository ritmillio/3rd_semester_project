using System.Runtime.Serialization;

namespace AirlineReservations.Model_Layer{

    [DataContract]
    public class Seat
    {
        private string seatId { get; set; }
        private string type { get; set; }
        private decimal price { get; set; }
        private string flightId { get; set; }
        private int bookingNo { get; set; }

        public Seat(string type, decimal price, string seatId){
            this.type = type; 
            this.price = price;
            this.seatId = seatId;
        }

        public Seat()
        {
        }

        [DataMember]
        public string SeatId
        {
            get { return seatId;}
            set { SeatId = value; }
        }

        [DataMember]
        public string Type{
            get{return type;}
            set{ type = value;}
        }

        [DataMember]
        public decimal Price{
            get{return price;}
            set{price = value;}
        }

        [DataMember]
        public string FlightId
        {
            get { return flightId; }
            set { flightId = value;}
        }

        [DataMember]
        public int BookingNo
        {
            get { return bookingNo; }
            set { bookingNo = value; }
        }
 

    }

}