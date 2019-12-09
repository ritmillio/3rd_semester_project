
using System;

namespace AirlineReservations.Model_Layer
{
    public class Flight
    {
        public int FlightNo { get; set; }
        public string Model { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Destination { get; set; }
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