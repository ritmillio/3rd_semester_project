namespace AirlineReservations.Model_Layer{
    public class Customer{
        private string name;
        private bool isAdmin;
        private int customerID;
        public Customer(string name , bool isAdmin){
            this.name = name;
            this.isAdmin = isAdmin;
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

        public int CustomerID{
            get{return customerID;}
            set{customerID = value;}
        }
    }
}