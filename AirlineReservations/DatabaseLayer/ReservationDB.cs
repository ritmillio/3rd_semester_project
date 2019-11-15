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
    class ReservationDB : ReservationDBIF
    {
        SqlConnectionStringBuilder conStringBuilder;
        SqlConnection con;
        public ReservationDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        private Reservation objectBuilder(SqlDataReader dataReader)
        {
            Reservation reservation = new Reservation(dataReader.GetString(0), dataReader.GetInt32(2));
            
            return reservation;
        }

        public int DeleteReservation(int bookingNo)
        {
            throw new NotImplementedException();
        }

        public ArrayList GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationById(int bookingNo)
        {
            throw new NotImplementedException();
        }

        public int InsertReservation(ReservationDBIF reservation)
        {
            throw new NotImplementedException();
        }

        public int UpdateReservation(int bookingNo, Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
