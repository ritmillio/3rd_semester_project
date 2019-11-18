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
            int result = 0;
            string deleteSeat = "DELETE * FROM Seat WHERE seatId = @seatId";
            using(SqlCommand command = new SqlCommand(deleteSeat, con))
            {
                command.Parameters.AddWithValue("@seatId", seatId);
                result = command.ExecuteNonQuery();
            }
            if (result == 1)
            {
                return (int)SqlResult.Success;
            }
            else
            {
                return (int)SqlResult.Failure;
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
            }
            con.Dispose();
            return seats;
        }

        public Seat GetSeatById(string seatId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getSeat = "SELECT * FROM Seat WHERE seatId = @seatId";
            Seat seat = null;
            using(SqlCommand command = new SqlCommand(getSeat, con))
            {
                command.Parameters.AddWithValue("@seatId", seatId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    seat = objectBuilder(dataReader);
                }
            }
            con.Dispose();
            return seat;
        }

        public int InsertSeat(Seat seat)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string insertSeat = "INSERT INTO Seat(seatId, seatType, isAvailable, price, flightId, bookingNo) " +
                "VALUES(@seatId, @seatType, @isAvailable, @price, @flightId, @bookingNo)";
            using(SqlCommand command = new SqlCommand(insertSeat, con))
            {
                //command.Parameters.AddWithValue("@seatId", )
            }
        }

        public int UpdateSeat(string seatId, Seat seat)
        {
            throw new NotImplementedException();
        }
    }
}
