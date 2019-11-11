namespace Model_Layor{
    public class Customer{
        private string name;
        private bool isAdmin;
        private string passportNo;
        public Customer(string name , bool isAdmin , string passportNo){
            this.name = name;
            this.isAdmin = isAdmin;
            this.passportNo = passportNo;
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

        public string PassportNo{
            get{return passportNo;}
            set{passportNo = value;}
        }
    }
}