using System.Collections.Generic;
using System.Dynamic;

namespace AirlineReservations.Model_Layer{

    public class Reservation{
        public int BookingNo { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }

        public Reservation(decimal price, int customerId = 1)
        {
            this.CustomerId = customerId;
            this.Price = price;
        }
    }
}