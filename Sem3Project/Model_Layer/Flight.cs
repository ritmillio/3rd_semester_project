
namespace Sem3Project.Model_Layer
{
    public class Flight
    {
        private string flightNo;
        private string model;
        private string departureTime; //not sure
        // DateTime departuretime = new DateTime(); could be i guess
        private string arrivalTime; // not sure
        // DateTime arrivalTime = new DateTime(); could be i guess
        private string destination;
        private string departureLocation;

        public Flight(string flightNo , string model , string departureTime , string arrivalTime , string destination , string departureLocation){
            this.flightNo = flightNo;
            this.model = model;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
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
        public string DepartureTime{
            get{return departureTime ;}
            set{this.departureTime = value;}
        }
        public string ArrivalTime{
            get{return arrivalTime ;}
            set{this.arrivalTime = value;}
        }
        public string Destination{
            get{return destination ;}
            set{this.destination = value;}
        }
        public string DepartureLocation{
            get{return departureLocation ;}
            set{this.departureLocation = value;}
        }

        //newFlight
    }
}