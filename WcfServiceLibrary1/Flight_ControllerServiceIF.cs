using System;
using System.Collections.Generic;
using System.ServiceModel;
using AirlineReservations.Model_Layer;

namespace AirlineReservations
{
    [ServiceContract]
    public interface Flight_ControllerServiceIF
    {
        [OperationContract]
        int NewFlight(string modelNo, DateTime departure, DateTime arrival);
        
        [OperationContract]
        Flight GetFlight(int flightID);

        [OperationContract]
        List<Flight> ListActiveFlights();

        [OperationContract]
        SuccessState CompleteFlight(string flightID);

        [OperationContract]
        SuccessState RemoveFlight(int flightID);

        [OperationContract]
        List<Seat> GetAllSeats(int flight_id);
           
    }
}
