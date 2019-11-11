namespace Model_Layor{

    public class Reservation{
        private string bookingNo;
        private List seats = new List<Seat>();
        private int price;

        public Reservation(string bookingNo , int price){
            this.bookingNo = bookingNo;
            this.price = price;
        }
        public string bookingNo
        {
            get { return bookingNo; }
            set { bookingNo = value; }
        }
        public var Price
        {
            get { return price; }
            set { price = value; }
        }
        public List<Seat> Seats{
            get{return seats;}
            set{seats = value;}
        }
    }''
}