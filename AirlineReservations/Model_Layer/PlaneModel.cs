namespace AirlineReservations.Model_Layer{
    public class Model {
        private long id; // maybe string ? 
        private byte numberOfSeats;

        public Model(long id,
                     byte numberOfSeats)
        {
            this.id = id;
            this.numberOfSeats = numberOfSeats;
        }

        public long Id{
            get{return id;}
            set{id = value;}
        }
        public byte NumberOfSeats{
            get{return numberOfSeats;}
            set{numberOfSeats = value;}
        }
    }
}