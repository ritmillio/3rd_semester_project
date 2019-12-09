using System.Collections.Generic;

namespace AirlineReservations.Model_Layer{
    public class Customer{
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public int CustomerId { get; set; }
        public List<string> BookingNos { get; set; }
        public Customer(string name , bool isAdmin){
            this.Name = name;
            this.IsAdmin = isAdmin;
            BookingNos = new List<string>();
        }
    }
}