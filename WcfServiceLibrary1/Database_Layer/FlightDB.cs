using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class FlightDb : IFlightDb
    {
        SqlConnectionStringBuilder _conStringBuilder = new SqlConnectionStringBuilder();
        SqlConnection _con;
        ISeatDb _seatdb;
        IModelDb _modeldb;

        public FlightDb()
        {
            _seatdb = new SeatDb();
            _modeldb = new ModelDb();

            _conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            _conStringBuilder.DataSource = "kraka.ucn.dk";
            _conStringBuilder.UserID = "dmaa0918_1071480";
            _conStringBuilder.Password = "Password1!";
        }

        private Flight ObjectBuilder(SqlDataReader dataReader)
        {
            //Builds a Flight object with data from the SqlDataReader
            Console.WriteLine(dataReader.GetInt32(0));
            Console.WriteLine(dataReader.GetDataTypeName(1));
            Console.WriteLine(dataReader.GetDateTime(1));
            Console.WriteLine(dataReader.GetDateTime(2));
            var flight = new Flight(dataReader.GetString(5), dataReader.GetDateTime(1),
                dataReader.GetDateTime(2), dataReader.GetString(4), dataReader.GetString(3))
            {
                FlightNo = dataReader.GetInt32(0)
            };
            return flight;
        }

        public SuccessState DeleteFlight(int flightNo)
        {
            //Open connection and write query with placeholder value
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string deleteFlight = "DELETE FROM Flight WHERE flightId = @flightId";
            int result;
            _seatdb.DeleteSeatByFlightId(flightNo);
            using(var command = new SqlCommand(deleteFlight, _con))
            {
                //Replace placeholder value and execute query
                command.Parameters.AddWithValue("@flightId", flightNo);
                result = command.ExecuteNonQuery();
            }
            //Result is the number of rows that were changed in the database.
            //It should always return 1 if the query succeeds, as the flightNo is unique in the database.
            if (result == 0)
            {
                _con.Dispose();
                return SuccessState.DbUnreachable;
            }
            _con.Dispose();
            return SuccessState.Success;
        }

        public List<Flight> GetAllFlights()
        {
            //Open new connection and write query
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            var flights = new List<Flight>();
            string getAllFlights = "SELECT * FROM Flight";
            _con.Open();

            using(var command = new SqlCommand(getAllFlights, _con))
            {
                //Execute SqlDataReader build object.
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    flights.Add(ObjectBuilder(dataReader));
                }
            }
            _con.Dispose();
            return flights;
        }

        public Flight GetFlightById(int flightNo)
        {
            //Open new connection and write query with placeholder value
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string getFlight = "SELECT * FROM Flight WHERE flightId = @flightId";
            Flight flight = null;
            using (var command = new SqlCommand(getFlight, _con))
            {
                //Replace placeholder value and execute SqlDataReader and build object
                command.Parameters.AddWithValue("@flightId", flightNo);
                var dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    flight = ObjectBuilder(dataReader);
                }
                    
            }
            return flight;
        }

        //Inserts Flight into Database
        public int InsertFlight(Flight flight)
        {
            //Open connection and write query string with placeholder parameters
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string insertFlight = "INSERT INTO Flight (departureTime, arrivalTime, departureLocation," +
                "destination, modelId) VALUES(@departureTime, @arrivalTime, @departureLocation, @destination, @modelId)" +
                "SELECT SCOPE_IDENTITY()";
            int flightId;
            using (var command = new SqlCommand(insertFlight, _con))
            {
                //Replace placeholder parameters and insert string. ExecuteScalar is used to return the flights ID
                command.Parameters.AddWithValue("@departureTime", flight.DepartureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.ArrivalTime);
                command.Parameters.AddWithValue("@departureLocation", flight.DepartureLocation);
                command.Parameters.AddWithValue("@destination", flight.Destination);
                command.Parameters.AddWithValue("@modelId", flight.Model);
                
                var result = command.ExecuteScalar().ToString();
                flightId = int.Parse(result);
            }
            //Inserts a number of seats based on numberOfSeats in the flights model
            
            var model = _modeldb.GetModelById(flight.Model);
            _seatdb.InsertMultipleSeats(model.NumberOfSeats, flightId, "default", 100.00);

            _con.Dispose();
            return flightId;
        }

        public SuccessState UpdateFlight(int flightNo, Flight flight)
        {
            //Open new connection and write query wit placeholder values
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string updateFlight = "UPDATE Flight SET departureTime = @departureTime, arrivalTime = @arrivalTime" +
                "departureLocation = @departureLocation, destination = @destination, modelId = @modelId WHERE flightId = @flightId";
            int result;
            using (var command = new SqlCommand(updateFlight, _con))
            {
                //Replace placeholder params with actual data and execute query.
                command.Parameters.AddWithValue("@flightid", flight.FlightNo);
                command.Parameters.AddWithValue("@departureTime", flight.DepartureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.ArrivalTime);
                command.Parameters.AddWithValue("@departureLocation", flight.DepartureLocation);
                command.Parameters.AddWithValue("@destination", flight.Destination);
                command.Parameters.AddWithValue("@modelId", flight.Model);
                result = command.ExecuteNonQuery();
                
            }
            _con.Dispose();
            //Return success state based on number of rows changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }
    }
}
