using System;
using System.Collections.Generic;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class FlightController
    {
        private FlightDBIF flight_db;
        private ModelDBIF model_db;

        //Instantiate the database
        public FlightController()
        {
            this.flight_db = new FlightDB();
            this.model_db = new ModelDB();
        }

        //Adds a new flight to the database based on a given model no, returns success state
        public SuccessState NewFlight(string modelNo, DateTime departure, DateTime arrival)
        {
            Model model = model_db.GetModelById(modelNo);
            if (model == null)
            {
                return SuccessState.BadInput;
            }
            Flight new_flight = new Flight(model, departure, arrival,
                "TODO", "Aalborg");

            return flight_db.InsertFlight(new_flight);
        }
        
        //Return the flight object of a flight with a given id
        public Flight GetFlight(string flightID)
        {
            return new Flight("", "", "", "", "", ""); // stub
        }
        
        //Return a list of all active flights
        public List<Flight> ListActiveFlights()
        {
            return new List<Flight>(); // stub
        }

        //Complete a given flight
        public SuccessState CompleteFlight(string flightID)
        {
            return  SuccessState.Success;
        }
        
        //Remove a given flight
        public int RemoveFlight(string flightID)
        {
            return (int) SuccessState.Success;
        }
    }
}