namespace Model_Layer
{
    public class Flight
    {
        private var flightNo;
        private var model;
        private var departureTime;
        private var arrivalTime;
        private var destination;
        private var departureLocation;

        public Flight(string flightNo , string model , var departureTime , var arrivalTime , var destination , var departureLocation){
            this.flightNo = flightNo;
            this.model = model;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.destination = destination;
            this.departureLocation = departureLocation;
        }

        public var flightNo{
            get{return flightNo ;}
            set{this.flightNo = value;}
        }
        public var model{
            get{return model ;}
            set{this.model = value;}
        }
        public var departureTime{
            get{return departureTime ;}
            set{this.departureTime = value;}
        }
        public var arrivalTime{
            get{return arrivalTime ;}
            set{this.arrivalTime = value;}
        }
        public var destination{
            get{return destination ;}
            set{this.destination = value;}
        }
        public var departureLocation{
            get{return departureLocation ;}
            set{this.departureLocation = value;}
        }

        
    }
}