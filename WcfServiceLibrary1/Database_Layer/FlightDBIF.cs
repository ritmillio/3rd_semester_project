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
        int InsertFlight(Flight flight);
        Flight GetFlightById(int flightNo);
        SuccessState DeleteFlight(int flightNo);
        SuccessState UpdateFlight(int flightNo, Flight flight);
        List<Flight> GetAllFlights();
        
    }
}
