using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
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

        //Builds Seat objects for GetSeat methods based on data from SqlDataReader
        private Seat ObjectBuilder(SqlDataReader dataReader)
        {
            Seat seat = new Seat(dataReader.GetString(1), 
                dataReader.GetDecimal(2), dataReader.GetString(0));
            if (!dataReader.IsDBNull(4))
            {
                seat.BookingNo = dataReader.GetInt32(4);
            }

            return seat;
        }

        public SuccessState DeleteSeat(string seatId)
        {
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string deleteSeat = "DELETE FROM Seat WHERE seatId = @seatId";
            using(SqlCommand command = new SqlCommand(deleteSeat, con))
            {
                //Replace placeholder value and execute query
                command.Parameters.AddWithValue("@seatId", seatId);
                result = command.ExecuteNonQuery();
                con.Dispose();
            }
            //Return SuccessState based on number of rows that were changed in DB
            if (result == 1)
            {
                return SuccessState.Success;
            }
            else
            {
                return SuccessState.DBUnreachable;
            }
        }
        public SuccessState DeleteSeatByFlightId(int flightId)
        {
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            int result = 0;
            string deleteSeat = "DELETE FROM Seat WHERE flightId = @flightId";
            using(SqlCommand command = new SqlCommand(deleteSeat, con))
            {
                //Replace placeholder parameters and execute query
                command.Parameters.AddWithValue("@flightId", flightId);
                con.Open();
                result = command.ExecuteNonQuery();
                con.Dispose();
            }
            if(result >= 1)
            {
                return SuccessState.Success;
            } else
            {
                return SuccessState.BadInput;
            }
        }

        public List<Seat> GetAllSeatsByFlight(int flightId)
        {
            //Open connection and write query string
            List<Seat> seats = new List<Seat>();
            string getAllSeats = "SELECT * FROM Seat WHERE flightId = @flightId";
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();

            using (SqlCommand command = new SqlCommand(getAllSeats, con))
            {
                //Execute SqlDataReader and build object
                command.Parameters.AddWithValue("@flightId", flightId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    seats.Add(ObjectBuilder(dataReader));
                }
            }
            con.Dispose();
            return seats;
        }

        public Seat GetSeatById(string seatId)
        {
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getSeat = "SELECT * FROM Seat WHERE seatId = @seatId";
            Seat seat = null;
            using(SqlCommand command = new SqlCommand(getSeat, con))
            {
                //Replace placeholder value, execute SqlDataReader, and build object
                command.Parameters.AddWithValue("@seatId", seatId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    seat = ObjectBuilder(dataReader);
                }
            }
            con.Dispose();
            return seat;
        }

        public List<Seat> GetSeatByBookingNo(int bookingNo)
        {
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getSeats = "SELECT * FROM Seat WHERE bookingNo = @bookingNo";
            List<Seat> seats = new List<Seat>();
            using (SqlCommand command = new SqlCommand(getSeats, con))
            {
                //Replace placeholder value, execute SqlDataReader, and build object
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    seats.Add(ObjectBuilder(dataReader));
                }
            }
            con.Dispose();
            return seats;
        }

        public SuccessState InsertSeat(Seat seat)
        {
            //Open connection and write query with placeholder values
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string insertSeat = "INSERT INTO Seat(seatId, seatType, price, flightId) " +
                "VALUES(@seatId, @seatType, @price, @flightId)";
            int result = 0;
            using(SqlCommand command = new SqlCommand(insertSeat, con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@seatId", seat.SeatId);
                command.Parameters.AddWithValue("@seatType", seat.Type);
                command.Parameters.AddWithValue("@price", seat.Price);
                command.Parameters.AddWithValue("@flightId", seat.FlightId);
                result = command.ExecuteNonQuery();
            }
            //Return SuccessState based on amount of rows changed in DB
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

        // remove boolean is an attempted workaround to be able to cleanly set the reservation back to null
        // TODO: remove is ugly, figure out something else
        public SuccessState UpdateSeat(string seatId, Seat seat, bool remove=false)
        {
            //Open connection and write query with placeholder values
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string updateSeat = "UPDATE Seat SET seatType = @seatType, price = @price, " +
                "bookingNo = @bookingNo WHERE seatId = @seatId";
            using(SqlCommand command = new SqlCommand(updateSeat, con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@seatId", seat.SeatId);
                command.Parameters.AddWithValue("@seatType", seat.Type);
                command.Parameters.AddWithValue("@price", seat.Price);
                if (remove)
                {
                    command.Parameters.AddWithValue("@bookingNo", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@bookingNo", seat.BookingNo);
                }
                result = command.ExecuteNonQuery();
            }
            //Return SuccessState based on amount of rows changed in DB
            if(result == 1)
            {
                return SuccessState.Success;
            } else
            {
                return SuccessState.DBUnreachable;
            }
        }

        public SuccessState InsertMultipleSeats(int numberOfSeats, int flightId, string seatType, double price)
        {
            //Open connection
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            //Creates Database Query String with 1 additional set of values for each numberOfSeats
            string insertSeat = "INSERT INTO Seat(seatId, seatType, price, flightId) " +
                "VALUES(@seatId, @seatType, @price, @flightId)";
            int result = 0;


            //Replaces placeholder values and inserts query into database
            using(SqlCommand command = new SqlCommand(insertSeat, con))
            {
                command.Parameters.Add(new SqlParameter("@seatId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@seatType", seatType));
                // TODO currently seats are only 1 type
                command.Parameters.Add(new SqlParameter("@price", price));
                command.Parameters.Add(new SqlParameter("@flightId", flightId));
                for (int i = 0; i < numberOfSeats; i++)
                {
                    command.Parameters[0].Value = flightId + "." + i;
                    command.ExecuteNonQuery();
                }

            }
            //Return SuccessState based on amount of rows added in DB
            if(result == numberOfSeats)
            {
                return SuccessState.Success;
            } else
            {
                return SuccessState.BadInput;
            }
            
        }
    }
}
