namespace AirlineReservations.Model_Layer{

    public class Seat
    {
        private string type;
        private byte row; 
        private byte column;
        private bool isAvailable;
        private bool modified{get;set;}
        private int price;

        public Seat(string type , byte row , byte column , bool isAvailable , int price){
            this.type = type; 
            this.row = row;
            this.column = column;
            this.isAvailable = isAvailable;
            this.price = price;
        }
        
        public string Type{
            get{return type;}
            set{ type = value;}
        }
        public byte Row{
            get{return row;}
            set{row = value;}
        }
        public byte Column{
            get{return column;}
            set{column = value;}
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