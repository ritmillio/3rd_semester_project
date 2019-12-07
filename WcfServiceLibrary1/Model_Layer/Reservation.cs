using System.Collections.Generic;
using System.Dynamic;

namespace AirlineReservations.Model_Layer{

    public class Reservation{
        private string bookingNo { get; set; }
        private decimal price { get; set; }
        private int customerId { get; set; }

        public Reservation(decimal price, int customerId = 1)
        {
            this.customerId = customerId;
            this.price = price;
        }
        
        public string BookingNo
        {
            get{ return bookingNo; }
            set { bookingNo = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
    }
}