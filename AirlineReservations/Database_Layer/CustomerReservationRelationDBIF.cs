using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;
using System.Data.SqlClient;

namespace AirlineReservations.DatabaseLayer
{
    interface CustomerReservationRelationDBIF
    {
        SuccessState InsertRelation(int bookingNo, int customerId, SqlConnection con);
        SuccessState DeleteRelationByBookingNo(int bookingNo, SqlConnection con);
        SuccessState DeleteRelationByCustomerId(int customerId, SqlConnection con);
        String GetCustomerIdByBookingNo(int bookingNo, SqlConnection con);
        String GetBookingNoByCustomerId(int customerId, SqlConnection con);
    }
}
