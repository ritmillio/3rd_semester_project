using System;
using System.Collections.Generic;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Control_Layer
{
    public class FlightController
    {
        private enum SuccessState
        {
            Success,
            BadInput,       // input is incorrect or invalid
            DBUnreachable   // database can not be connected to
        }

        //Instantiate the database
        public FlightController()
        {
            return;
        }

        //Adds a new flight to the database based on a given model no, returns success state
        public int NewFlight(string modelNo)
        {
            return (int)SuccessState.Success;
        }
        
        //Return a list of all active flights
        public List<Flight> ListActiveFlights()
        {
            return new List<Flight>(); // stub
        }

        //Complete a given flight
        public int CompleteFlight(string flightID)
        {
            return (int) SuccessState.Success;
        }
        
        //Remove a given flight
        public int RemoveFlight(string flightID)
        {
            return (int) SuccessState.Success;
        }
        
        //Reserve a given seat(s) for a given flight (add multiple to avoid race conditions)
        public int ReserveSeat(List<Seat> seats)
        {
            return (int) SuccessState.Success;
        }
        
        //Cancel seat reservation (multiple are not needed, no race conditions)
        public int CancelSeat(Seat seat)
        {
            return (int) SuccessState.Success;
        }
    }
}