using System;
using System.Runtime.Serialization;

namespace AirlineReservations.Model_Layer
{
    [DataContract]
    public class Flight
    {
        private int flightNo;
        private string model;
        DateTime departure_time;
        DateTime arrival_time;
        private string destination;
        private string departureLocation;

        public Flight(string model , DateTime departure_time , DateTime arrival_time , string destination , string departureLocation){
            this.model = model;
            this.departure_time = departure_time;
            this.arrival_time = arrival_time;
            this.destination = destination;
            this.departureLocation = departureLocation;
        }
        [DataMember]
        public int FlightNo{
            get{return flightNo ;}
            set{this.flightNo = value;}
        }
        [DataMember]
        public string Model{
            get{return model ;}
            set{this.model = value;}
        }
        [DataMember]
        public DateTime DepartureTime{
            get{return departure_time ;}
            set{this.departure_time = value;}
        }
        [DataMember]
        public DateTime ArrivalTime{
            get{return arrival_time ;}
            set{this.arrival_time = value;}
        }
        [DataMember]
        public string Destination{
            get{return destination ;}
            set{this.destination = value;}
        }
        [DataMember]
        public string DepartureLocation{
            get{return departureLocation ;}
            set{this.departureLocation = value;}
        }
    }
}