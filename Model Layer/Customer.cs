namespace Model_Layor{
    public class Customer{
        private var name;
        private bool isAdmin;
        private var passportNo;
        public Customer(var name , bool isAdmin , var passportNo){
            this.name = name;
            this.isAdmin = isAdmin;
            this.passportNo = passportNo;
        }
        public var Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set {isAdmin = value;}
        }

        public var PassportNo{
            get{return passportNo;}
            set{passportNo = value;}
        }
    }
}