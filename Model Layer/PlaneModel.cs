using System;

namespace Model_Layer{
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
            set{numberOfSeats = value;}
        }
    }
}