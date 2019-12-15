using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class SeatDb : ISeatDb
    {
        private readonly SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();

        public SeatDb()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        public SuccessState DeleteSeat(string seatId)
        {
            int result;
            var deleteSeat = "DELETE FROM Seat WHERE seatId = @seatId";

            //Open connection and write query with placeholder value
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(deleteSeat, con))
                {
                    //Replace placeholder value and execute query
                    command.Parameters.AddWithValue("@seatId", seatId);
                    result = command.ExecuteNonQuery();
                }
            }

            //Return SuccessState based on number of rows that were changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        public SuccessState DeleteSeatByFlightId(int flightId, SqlConnection con = null)
        {
            int result;
            var deleteSeat = "DELETE FROM Seat WHERE flightId = @flightId";
            var newConFlag = false;
            if (con == null)
            {
                con = new SqlConnection(conStringBuilder.ConnectionString);
                con.Open();
                newConFlag = true;
            }

            //Open connection and write query with placeholder value
            using (var command = new SqlCommand(deleteSeat, con))
            {
                //Replace placeholder parameters and execute query
                command.Parameters.AddWithValue("@flightId", flightId);
                result = command.ExecuteNonQuery();
            }

            // dispose connection if it was created here
            if (newConFlag) con.Dispose();
            return result >= 1 ? SuccessState.Success : SuccessState.BadInput;
        }

        public List<Seat> GetAllSeatsByFlight(int flightId)
        {
            //Open connection and write query string
            var seats = new List<Seat>();
            var getAllSeats = "SELECT * FROM Seat WHERE flightId = @flightId";
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();

                using (var command = new SqlCommand(getAllSeats, con))
                {
                    //Execute SqlDataReader and build object
                    command.Parameters.AddWithValue("@flightId", flightId);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read()) seats.Add(ObjectBuilder(dataReader));
                }
            }

            return seats;
        }

        public Seat GetSeatById(string seatId, SqlConnection con = null)
        {
            var getSeat = "SELECT * FROM Seat WHERE seatId = @seatId";
            var newConFlag = false;
            Seat seat = null;
            if (con == null)
            {
                con = new SqlConnection(conStringBuilder.ConnectionString);
                con.Open();
                newConFlag = true;
            }


            //Open connection and write query with placeholder value
            using (var command = new SqlCommand(getSeat, con))
            {
                //Replace placeholder value, execute SqlDataReader, and build object
                command.Parameters.AddWithValue("@seatId", seatId);
                var dataReader = command.ExecuteReader();
                if (dataReader.Read()) seat = ObjectBuilder(dataReader);
            }
            
            // dispose connection if it was created here
            if (newConFlag) con.Dispose();
            return seat;
        }

        public List<Seat> GetSeatByBookingNo(int bookingNo)
        {
            var getSeats = "SELECT * FROM Seat WHERE bookingNo = @bookingNo";
            var seats = new List<Seat>();

            //Open connection and write query with placeholder value
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(getSeats, con))
                {
                    //Replace placeholder value, execute SqlDataReader, and build object
                    command.Parameters.AddWithValue("@bookingNo", bookingNo);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read()) seats.Add(ObjectBuilder(dataReader));
                }
            }

            return seats;
        }

        public SuccessState InsertSeat(Seat seat)
        {
            var insertSeat = "INSERT INTO Seat(seatId, seatType, price, flightId) " +
                             "VALUES(@seatId, @seatType, @price, @flightId)";
            int result;

            //Open connection and write query with placeholder values
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(insertSeat, con))
                {
                    //Replace placeholder values and execute query
                    command.Parameters.AddWithValue("@seatId", seat.SeatId);
                    command.Parameters.AddWithValue("@seatType", seat.Type);
                    command.Parameters.AddWithValue("@price", seat.Price);
                    command.Parameters.AddWithValue("@flightId", seat.FlightId);
                    result = command.ExecuteNonQuery();
                }
            }

            //Return SuccessState based on amount of rows changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        public SuccessState UpdateSeat(Seat seat, bool remove = false, SqlConnection con = null)
        {
            var result = 0;
            var newConFlag = false;
            var updateSeat = "UPDATE Seat SET seatType = @seatType, price = @price, " +
                             "bookingNo = @bookingNo WHERE seatId = @seatId";

            if (con == null)
            {
                con = new SqlConnection(conStringBuilder.ConnectionString);
                con.Open();
                newConFlag = true;
            }

            //write query with placeholder values
            using (var command = new SqlCommand(updateSeat, con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@seatId", seat.SeatId);
                command.Parameters.AddWithValue("@seatType", seat.Type);
                command.Parameters.AddWithValue("@price", seat.Price);
                if (remove)
                    command.Parameters.AddWithValue("@bookingNo", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@bookingNo", seat.BookingNo);

                result = command.ExecuteNonQuery();
            }
            
            // dispose connection if it was created here
            if (newConFlag) con.Dispose();
            
            //Return SuccessState based on amount of rows changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        public SuccessState InsertMultipleSeats(int numberOfSeats, int flightId, string seatType, double price,
            SqlConnection con = null)
        {
            //Creates Database Query String with 1 additional set of values for each numberOfSeats
            var result = 0;
            var newConFlag = false;
            var insertSeat = "INSERT INTO Seat(seatId, seatType, price, flightId) " +
                             "VALUES(@seatId, @seatType, @price, @flightId)";

            if (con == null)
            {
                con = new SqlConnection(conStringBuilder.ConnectionString);
                con.Open();
                newConFlag = true;
            }

            //Replaces placeholder values and inserts query into database
            using (var command = new SqlCommand(insertSeat, con))
            {
                command.Parameters.Add(new SqlParameter("@seatId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@seatType", seatType));
                // TODO currently seats are only 1 type
                command.Parameters.Add(new SqlParameter("@price", price));
                command.Parameters.Add(new SqlParameter("@flightId", flightId));
                for (var i = 0; i < numberOfSeats; i++)
                {
                    command.Parameters[0].Value = flightId + "." + i;
                    result += command.ExecuteNonQuery();
                }
            }
            // dispose connection if it was created here
            if (newConFlag) con.Dispose();

            //Return SuccessState based on amount of rows added in DB
            return result == numberOfSeats ? SuccessState.Success : SuccessState.BadInput;
        }

        //Builds Seat objects for GetSeat methods based on data from SqlDataReader
        private Seat ObjectBuilder(SqlDataReader dataReader)
        {
            var seat = new Seat(dataReader.GetString(1),
                dataReader.GetDecimal(2), dataReader.GetString(0));
            if (!dataReader.IsDBNull(4)) seat.BookingNo = dataReader.GetInt32(4);

            return seat;
        }
    }
}