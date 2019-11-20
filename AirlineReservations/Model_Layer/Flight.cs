
using System;

namespace AirlineReservations.Model_Layer
{
    public class Flight
    {
        private string flightNo = "unsigned";
        private string model;
        DateTime departure_time = new DateTime();
        DateTime arrival_time = new DateTime();
        private string destination;
        private string departureLocation;

        public Flight(string model , DateTime departureTime , DateTime arrivalTime , string destination , string departureLocation){
            this.model = model;
            this.departure_time = departureTime;
            this.arrival_time = arrivalTime;
            this.destination = destination;
            this.departureLocation = departureLocation;
        }

        public string FlightNo{
            get{return flightNo ;}
            set{this.flightNo = value;}
        }
        public string Model{
            get{return model ;}
            set{this.model = value;}
        }
        public DateTime DepartureTime{
            get{return departure_time ;}
            set{this.departure_time = value;}
        }
        public DateTime ArrivalTime{
            get{return arrival_time ;}
            set{this.arrival_time = value;}
        }
        public string Destination{
            get{return destination ;}
            set{this.destination = value;}
        }
        public string DepartureLocation{
            get{return departureLocation ;}
            set{this.departureLocation = value;}
        }
    }
}