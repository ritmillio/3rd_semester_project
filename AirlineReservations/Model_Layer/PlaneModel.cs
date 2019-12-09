namespace AirlineReservations.Model_Layer{
    public class Model {
        public string Id { get; set; }
        public int NumberOfSeats { get; set; }

        public Model(string id,
                     int numberOfSeats)
        {
            this.Id = id;
            this.NumberOfSeats = numberOfSeats;
        }

    }
}