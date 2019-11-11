namespace Model_Layer{

    public class Seat
    {
        private var type;
        private var row; 
        private var column;
        private bool isAvailable;
        private bool modified{get;set;}
        private var price;

        public Seat(var type , var row , var column , bool isAvailable , var price){
            this.type = type; 
            this.row = row;
            this.column = column;
            this.isAvailable = isAvailable;
            this.price = price;
        }
        
        public var Type{
            get{return type;}
            set{ type = value;}
        }
        public var Row{
            get{return row;}
            set{row = value;}
        }
        public var Column{
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
        public var Price{
            get{return price;}
            set{price=value;}
        }
 

    }

}