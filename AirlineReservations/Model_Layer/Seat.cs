namespace AirlineReservations.Model_Layer{

    public class Seat
    {
        private string SeatId { get; }
        private string type;
        private bool isAvailable;
        private bool modified{get;set;}
        private int price;

        public Seat(string type , bool isAvailable , int price, string seatId){
            this.type = type; 
            this.isAvailable = isAvailable;
            this.price = price;
            SeatId = seatId;
        }
        
        public string Type{
            get{return type;}
            set{ type = value;}
        }
        
        public bool IsAvailable{
            get{return isAvailable;}
            set{
                isAvailable = value;
                modified = true;
            }
        }
        public int Price{
            get{return price;}
            set{price = value;}
        }
 

    }

}