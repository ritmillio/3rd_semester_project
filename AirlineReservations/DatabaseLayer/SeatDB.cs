using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    class SeatDB : SeatDBIF
    {
        private SqlConnectionStringBuilder conStringBuilder;
        private SqlConnection con;

        public SeatDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        private Seat objectBuilder(SqlDataReader dataReader)
        {
            Seat seat = new Seat(dataReader.GetString(1), );
            return seat;
        }

        public int DeleteSeat(string seatId)
        {
            throw new NotImplementedException();
        }

        public ArrayList GetAllSeats()
        {
            throw new NotImplementedException();
        }

        public Seat GetSeatById(string seatId)
        {
            throw new NotImplementedException();
        }

        public int InsertSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        public int UpdateSeat(string seatId, Seat seat)
        {
            throw new NotImplementedException();
        }
    }
}
