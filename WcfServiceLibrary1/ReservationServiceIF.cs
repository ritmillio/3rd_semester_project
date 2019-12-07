using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;
using System.ServiceModel;

namespace AirlineReservations
{
    [ServiceContract]
    public interface ReservationServiceIF
    {
        [OperationContract]
        int NewReservation(List<Seat> seats, int customer_id = 1);
        [OperationContract]
        SuccessState ReleaseReservation(int bookingNo);
    }
}
