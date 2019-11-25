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
    public class SeatDB : SeatDBIF
    {
        private SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();
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

        public SuccessState DeleteSeat(string seatId)
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
                return SuccessState.Success;
            }
            else
            {
                return SuccessState.DBUnreachable;
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

        public SuccessState InsertSeat(Seat seat)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string insertSeat = "INSERT INTO Seat(seatId, seatType, isAvailable, price, flightId) " +
                "VALUES(@seatId, @seatType, @isAvailable, @price, @flightId)";
            int result = 0;
            using(SqlCommand command = new SqlCommand(insertSeat, con))
            {
                command.Parameters.AddWithValue("@seatId", seat.SeatId);
                command.Parameters.AddWithValue("@seatType", seat.Type);
                command.Parameters.AddWithValue("@isAvailable", seat.IsAvailable);
                command.Parameters.AddWithValue("@price", seat.Price);
                command.Parameters.AddWithValue("@flightId", seat.FlightId);
                result = command.ExecuteNonQuery();
            }
            if(result == 1)
            {
                con.Dispose();
                return SuccessState.Success;
            } else
            {
                con.Dispose();
                return SuccessState.DBUnreachable;
            }
        }

        public SuccessState UpdateSeat(string seatId, Seat seat)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string updateSeat = "UPDATE Seat SET seatType = @seatType, isAvailable = @isAvailable, price = @price, " +
                "flightId = @flightId, bookingNo = @bookingNo WHERE seatId = @seatId";
            using(SqlCommand command = new SqlCommand(updateSeat, con))
            {
                command.Parameters.AddWithValue("@seatId", seat.SeatId);
                command.Parameters.AddWithValue("@seatType", seat.Type);
                command.Parameters.AddWithValue("@isAvailable", seat.IsAvailable);
                command.Parameters.AddWithValue("@price", seat.Price);
                command.Parameters.AddWithValue("@flightId", seat.FlightId);
                command.Parameters.AddWithValue("@bookingNo", seat.BookingNo);
                result = command.ExecuteNonQuery();
            }
            if(result == 1)
            {
                return SuccessState.Success;
            } else
            {
                return SuccessState.DBUnreachable;
            }
        }

        public SuccessState InsertMultipleSeats(int numberOfSeats, int flightId, double price)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            //Creates Database Query String with 1 additional set of values for each numberOfSeats
            string insertMultipleSeats = "INSERT INTO Seat(seatId, price, flightId) VALUES";
            int result = 0;
            for(int i = 0; i < numberOfSeats; i++)
            {
                insertMultipleSeats += "('" + flightId + "." + i + "', @price" + i + ", @flightId" + i + ")";
                if(i < numberOfSeats - 1)
                {
                    insertMultipleSeats += ",";
                }
            }
            //Replaces placeholder values and inserts query into database
            using(SqlCommand command = new SqlCommand(insertMultipleSeats, con))
            {
                for (int i = 0; i < numberOfSeats; i++)
                {
                    command.Parameters.Add(new SqlParameter("@price" + i, price));
                    command.Parameters.Add(new SqlParameter("@flightId" + i, flightId));
                }

                Console.WriteLine(command.CommandText);
                result = command.ExecuteNonQuery();
            }
            if(result == 1)
            {
                return SuccessState.Success;
            } else
            {
                return SuccessState.BadInput;
            }
            
        }
    }
}
