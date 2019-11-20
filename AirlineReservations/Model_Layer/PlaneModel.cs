namespace AirlineReservations.Model_Layer{
    public class Model {
        private string id;
        private int numberOfSeats;

        public Model(string id,
                     int numberOfSeats)
        {
            this.id = id;
            this.numberOfSeats = numberOfSeats;
        }

        public string Id{
            get{return id;}
            set{id = value;}
        }
        public int NumberOfSeats{
            get{return numberOfSeats;}
            set{numberOfSeats = value;}
        }
    }
}