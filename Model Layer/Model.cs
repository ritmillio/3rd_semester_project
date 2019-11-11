namespace Model_Layor{
    public class Model : Flight{
        private var id;
        private var numberOfSeats;

        public Model(var id, var numberOfSeats){
            this.id = id;
            this.numberOfSeats = numberOfSeats;
        }

        public var Id{
            get{return id;}
            set{id = value;}
        }
        public var NumberOfSeats{
            get{return numberOfSeats;}
            set{if(numberOfSeats>50){
                throw new ArgumentException("Too many");
            }else{
                numberOfSeats = value;
            }}
        }
    }
}