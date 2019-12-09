using System.Collections.Generic;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public interface IFlightDb
    {
        int InsertFlight(Flight flight);
        Flight GetFlightById(int flightNo);
        SuccessState DeleteFlight(int flightNo);
        SuccessState UpdateFlight(int flightNo, Flight flight);
        List<Flight> GetAllFlights();
        
    }
}
