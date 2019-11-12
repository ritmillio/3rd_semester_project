using System.Collections.Generic;

namespace Model_Layer{

    public class Reservation{
        private string bookingNo;
        private List<string> seats = new List<string>(); 
        private int price;

        public Reservation(string bookingNo , int price){
            this.SetbookingNo(bookingNo);
            this.price = price;
        }
        
        //bookingNo getter/setter
        public string GetbookingNo()
        { return GetbookingNo(); }
        public void SetbookingNo(string value)
        { SetbookingNo(value); }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}