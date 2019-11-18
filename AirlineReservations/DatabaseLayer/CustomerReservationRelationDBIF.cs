using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    interface CustomerReservationRelationDBIF
    {
        int InsertRelation();
        int DeleteRelation();
        String GetCustomerIdByBookingNo();
        String GetBookingNoByCustomerId();
    }
}
