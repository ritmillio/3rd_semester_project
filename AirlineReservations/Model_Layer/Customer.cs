namespace AirlineReservations.Model_Layer{
    public class Customer{
        private string name;
        private bool isAdmin;
        private string customerID;
        public Customer(string name , bool isAdmin , string customerID){
            this.name = name;
            this.isAdmin = isAdmin;
            this.customerID = customerID;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set {isAdmin = value;}
        }

        public string CustomerID{
            get{return customerID;}
            set{customerID = value;}
        }
    }
}