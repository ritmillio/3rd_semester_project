namespace Model_Layor{

    public class Reservation{
        private var bookingNo;
        private var seats = new List<Seat>();
        private var price;

        public Reservation(var bookingNo , var price){
            this.bookingNo = bookingNo;
            this.price = price;
        }
        public var bookingNo
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