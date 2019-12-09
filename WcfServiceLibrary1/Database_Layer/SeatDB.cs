using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class SeatDb : ISeatDb
    {
        private SqlConnectionStringBuilder _conStringBuilder = new SqlConnectionStringBuilder();
        private SqlConnection _con;

        public SeatDb()
        {
            _conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            _conStringBuilder.DataSource = "kraka.ucn.dk";
            _conStringBuilder.UserID = "dmaa0918_1071480";
            _conStringBuilder.Password = "Password1!";
        }

        //Builds Seat objects for GetSeat methods based on data from SqlDataReader
        private Seat ObjectBuilder(SqlDataReader dataReader)
        {
            var seat = new Seat(dataReader.GetString(1), 
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
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            int result;
            string deleteSeat = "DELETE FROM Seat WHERE seatId = @seatId";
            using(var command = new SqlCommand(deleteSeat, _con))
            {
                //Replace placeholder value and execute query
                command.Parameters.AddWithValue("@seatId", seatId);
                result = command.ExecuteNonQuery();
                _con.Dispose();
            }
            //Return SuccessState based on number of rows that were changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }
        public SuccessState DeleteSeatByFlightId(int flightId)
        {
            //Open connection and write query with placeholder value
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            int result;
            string deleteSeat = "DELETE FROM Seat WHERE flightId = @flightId";
            using(var command = new SqlCommand(deleteSeat, _con))
            {
                //Replace placeholder parameters and execute query
                command.Parameters.AddWithValue("@flightId", flightId);
                _con.Open();
                result = command.ExecuteNonQuery();
                _con.Dispose();
            }
            return result >= 1 ? SuccessState.Success : SuccessState.BadInput;
        }

        public List<Seat> GetAllSeatsByFlight(int flightId)
        {
            //Open connection and write query string
            var seats = new List<Seat>();
            string getAllSeats = "SELECT * FROM Seat WHERE flightId = @flightId";
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();

            using (SqlCommand command = new SqlCommand(getAllSeats, _con))
            {
                //Execute SqlDataReader and build object
                command.Parameters.AddWithValue("@flightId", flightId);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    seats.Add(ObjectBuilder(dataReader));
                }
            }
            _con.Dispose();
            return seats;
        }

        public Seat GetSeatById(string seatId)
        {
            //Open connection and write query with placeholder value
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string getSeat = "SELECT * FROM Seat WHERE seatId = @seatId";
            Seat seat = null;
            using(var command = new SqlCommand(getSeat, _con))
            {
                //Replace placeholder value, execute SqlDataReader, and build object
                command.Parameters.AddWithValue("@seatId", seatId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    seat = ObjectBuilder(dataReader);
                }
            }
            _con.Dispose();
            return seat;
        }

        public List<Seat> GetSeatByBookingNo(int bookingNo)
        {
            //Open connection and write query with placeholder value
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string getSeats = "SELECT * FROM Seat WHERE bookingNo = @bookingNo";
            var seats = new List<Seat>();
            using (var command = new SqlCommand(getSeats, _con))
            {
                //Replace placeholder value, execute SqlDataReader, and build object
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    seats.Add(ObjectBuilder(dataReader));
                }
            }
            _con.Dispose();
            return seats;
        }

        public SuccessState InsertSeat(Seat seat)
        {
            //Open connection and write query with placeholder values
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string insertSeat = "INSERT INTO Seat(seatId, seatType, price, flightId) " +
                "VALUES(@seatId, @seatType, @price, @flightId)";
            int result;
            using(var command = new SqlCommand(insertSeat, _con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@seatId", seat.SeatId);
                command.Parameters.AddWithValue("@seatType", seat.Type);
                command.Parameters.AddWithValue("@price", seat.Price);
                command.Parameters.AddWithValue("@flightId", seat.FlightId);
                result = command.ExecuteNonQuery();
            }
            _con.Dispose();
            //Return SuccessState based on amount of rows changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        // remove boolean is an attempted workaround to be able to cleanly set the reservation back to null
        // TODO: remove is ugly, figure out something else
        public SuccessState UpdateSeat(string seatId, Seat seat, bool remove=false)
        {
            //Open connection and write query with placeholder values
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            int result;
            string updateSeat = "UPDATE Seat SET seatType = @seatType, price = @price, " +
                "bookingNo = @bookingNo WHERE seatId = @seatId";
            using(var command = new SqlCommand(updateSeat, _con))
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
            _con.Dispose();
            //Return SuccessState based on amount of rows changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        public SuccessState InsertMultipleSeats(int numberOfSeats, int flightId, string seatType, double price)
        {
            //Open connection
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            //Creates Database Query String with 1 additional set of values for each numberOfSeats
            string insertSeat = "INSERT INTO Seat(seatId, seatType, price, flightId) " +
                "VALUES(@seatId, @seatType, @price, @flightId)";
            var result = 0;


            //Replaces placeholder values and inserts query into database
            using(var command = new SqlCommand(insertSeat, _con))
            {
                command.Parameters.Add(new SqlParameter("@seatId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@seatType", seatType));
                // TODO currently seats are only 1 type
                command.Parameters.Add(new SqlParameter("@price", price));
                command.Parameters.Add(new SqlParameter("@flightId", flightId));
                for (var i = 0; i < numberOfSeats; i++)
                {
                    command.Parameters[0].Value = flightId + "." + i;
                    command.ExecuteNonQuery();
                }

            }
            //Return SuccessState based on amount of rows added in DB
            return result == numberOfSeats ? SuccessState.Success : SuccessState.BadInput;
            
        }
    }
}
