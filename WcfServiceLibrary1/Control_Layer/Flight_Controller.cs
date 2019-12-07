using System;
using System.Collections;
using System.Collections.Generic;
using AirlineReservations.DatabaseLayer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class FlightController : Flight_ControllerServiceIF
    {
        private FlightDBIF flight_db;
        private ModelDBIF model_db;
        private SeatDBIF seat_db;

        //Instantiate the database
        public FlightController()
        {
            this.flight_db = new FlightDB();
            this.model_db = new ModelDB();
            this.seat_db = new SeatDB();
        }

        //Adds a new flight to the database based on a given model no, returns ID of the flight created
        public int NewFlight(string modelNo, DateTime departure, DateTime arrival)
        {
            // Check that the model exists
            var model = model_db.GetModelById(modelNo);
            if (model == null)
            {
                return -1;
            }
            Flight new_flight = new Flight(modelNo, departure, arrival,
                "TODO", "Aalborg");

            return flight_db.InsertFlight(new_flight);
        }
        
        //Return the flight object of a flight with a given id
        public Flight GetFlight(int flightID)
        {
            return flight_db.GetFlightById(flightID);
        }
        
        //Return a list of all active flights
        public List<Flight> ListActiveFlights()
        {
            return flight_db.GetAllFlights();
        }

        //Complete a given flight, reservations can no longer be made
        public SuccessState CompleteFlight(string flightID)
        {
            return  SuccessState.Success;
            // TODO: There are no database features for this yet
        }
        
        //Remove a given flight
        public SuccessState RemoveFlight(int flightID)
        {
            return flight_db.DeleteFlight(flightID);
        }

        //Get all seats for a specific flight
        public List<Seat> GetAllSeats(int flight_id)
        {
            return seat_db.GetAllSeatsByFlight(flight_id);
        }
    }
}