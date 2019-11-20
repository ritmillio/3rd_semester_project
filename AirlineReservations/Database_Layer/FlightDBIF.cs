using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    public interface FlightDBIF
    {
        SuccessState InsertFlight(Flight flight);
        Flight GetFlightById(string flightNo);
        SuccessState DeleteFlight(string flightNo);
        SuccessState UpdateFlight(string flightNo, Flight flight);
        ArrayList GetAllFlights();
        
    }
}
