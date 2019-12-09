using System.Runtime.Serialization;

namespace AirlineReservations.Model_Layer{

    [DataContract]
    public class Seat
    {
        [DataMember]
        public string SeatId { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string FlightId { get; set; }
        [DataMember]
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