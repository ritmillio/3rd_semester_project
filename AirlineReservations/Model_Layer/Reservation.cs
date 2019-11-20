using System.Collections.Generic;

namespace AirlineReservations.Model_Layer{

    public class Reservation{
        private string bookingNo { get; set; }
        private int numberOfSeats { get; set; }
        private decimal price { get; set; }

        public Reservation(string bookingNo , int price){
            this.bookingNo = bookingNo;
            this.price = price;
        }
        
        //bookingNo getter/setter
        
        public string BookingNo
        {
            get{ return bookingNo; }
            set { bookingNo = value; }
        }

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}