using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    enum SqlResult
    {
        Failure,
        Success
    }

    public interface FlightDBIF
    {
        int InsertFlight(Flight flight);
        Flight GetFlightById(string flightNo);
        int DeleteFlight(string flightNo);
        int UpdateFlight(string flightNo, Flight flight);
        ArrayList GetAllFlights();
        
    }
}
