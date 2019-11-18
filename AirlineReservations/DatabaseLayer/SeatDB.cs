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
            Seat seat = new Seat(dataReader.GetString(1), dataReader.GetBoolean(2), 
                dataReader.GetDecimal(3), dataReader.GetString(0));
            return seat;
        }

        public int DeleteSeat(string seatId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteSeat = "DELETE * FROM Seat WHERE seatId = @seatId";
            using(SqlCommand command = new SqlCommand(deleteSeat, con))
            {
                command.Parameters.AddWithValue("@seatId", seatId);
                int result = command.ExecuteNonQuery();
                if(result == 1)
                {
                    return (int)SqlResult.Success;
                } else
                {
                    return (int)SqlResult.Failure;
                }
            }
        }

        public ArrayList GetAllSeats()
        {
            ArrayList seats = new ArrayList();
            string getAllSeats = "SELECT * FROM Seat";
            con.Open();

            using (SqlCommand command = new SqlCommand(getAllSeats, con))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    seats.Add(objectBuilder(dataReader));
                }
                return seats;
            }
        }

        public Seat GetSeatById(string seatId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
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
