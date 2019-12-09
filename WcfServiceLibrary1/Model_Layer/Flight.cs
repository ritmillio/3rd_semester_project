using System;
using System.Runtime.Serialization;

namespace AirlineReservations.Model_Layer
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        public int FlightNo { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public DateTime DepartureTime { get; set; }
        [DataMember]
        public DateTime ArrivalTime { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public string DepartureLocation { get; set; }

        public Flight(string model , DateTime departureTime , DateTime arrivalTime , string destination , string departureLocation){
            this.Model = model;
            this.DepartureTime = departureTime;
            this.ArrivalTime = arrivalTime;
            this.Destination = destination;
            this.DepartureLocation = departureLocation;
        }
    }
}