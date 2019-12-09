using System;
using System.Collections;
using System.Collections.Generic;
using AirlineReservations.Database_Layer;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class FlightController
    {
        private IFlightDb _flightDb;
        private IModelDb _modelDb;
        private ISeatDb _seatDb;

        //Instantiate the database
        public FlightController()
        {
            this._flightDb = new FlightDb();
            this._modelDb = new ModelDb();
            this._seatDb = new SeatDb();
        }

        //Adds a new flight to the database based on a given model no, returns ID of the flight created
        public int NewFlight(string modelNo, DateTime departure, DateTime arrival)
        {
            // Check that the model exists
            var model = _modelDb.GetModelById(modelNo);
            if (model == null)
            {
                return -1;
            }
            var newFlight = new Flight(modelNo, departure, arrival,
                "TODO", "Aalborg");

            return _flightDb.InsertFlight(newFlight);
        }
        
        //Return the flight object of a flight with a given id
        public Flight GetFlight(int flightId)
        {
            return _flightDb.GetFlightById(flightId);
        }
        
        //Return a list of all active flights
        public List<Flight> ListActiveFlights()
        {
            return _flightDb.GetAllFlights();
        }

        //Complete a given flight, reservations can no longer be made
        public SuccessState CompleteFlight(string flightId)
        {
            return  SuccessState.Success;
            // TODO: There are no database features for this yet
        }
        
        //Remove a given flight
        public SuccessState RemoveFlight(int flightId)
        {
            return _flightDb.DeleteFlight(flightId);
        }

        //Get all seats for a specific flight
        public List<Seat> GetAllSeats(int flightId)
        {
            return _seatDb.GetAllSeatsByFlight(flightId);
        }
    }
}