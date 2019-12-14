using System;
using System.Transactions;
using System.Collections.Generic;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class FlightDb : IFlightDb
    {
        private SqlConnectionStringBuilder _conStringBuilder = new SqlConnectionStringBuilder();
        private SqlConnection _con;
        private ISeatDb _seatdb;
        private IModelDb _modeldb;

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

        //Delete a flight given its ID
        public SuccessState DeleteFlight(int flightNo)
        {
            string deleteFlight = "DELETE FROM Flight WHERE flightId = @flightId";
            int result;

            using (var scope = new TransactionScope())
            {
                //Open connection and write query with placeholder value
                using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
                {
                    _con.Open();

                    //Delete seats associated with the flight
                    var output = _seatdb.DeleteSeatByFlightId(flightNo);

                    //Abort transaction if it failed, before an imminent foreign key error
                    if (output != SuccessState.Success) return SuccessState.DbUnreachable;

                    using (var command = new SqlCommand(deleteFlight, _con))
                    {
                        //Replace placeholder value and execute query
                        command.Parameters.AddWithValue("@flightId", flightNo);
                        result = command.ExecuteNonQuery();
                    }

                }
                //Complete transaction if 1 row affected
                if (result == 1) scope.Complete();
            }
            return SuccessState.Success;
        }

        public List<Flight> GetAllFlights()
        {
            var flights = new List<Flight>();
            string getAllFlights = "SELECT * FROM Flight";
            
            //Open new connection and write query
            using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
            {
                _con.Open();

                using (var command = new SqlCommand(getAllFlights, _con))
                {
                    //Execute SqlDataReader build object.
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        flights.Add(ObjectBuilder(dataReader));
                    }
                }
            }
            return flights;
        }

        public Flight GetFlightById(int flightNo)
        {
            string getFlight = "SELECT * FROM Flight WHERE flightId = @flightId";
            Flight flight = null;
            
            //Open new connection and write query with placeholder value
            using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
            {
                _con.Open();
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
            }
            return flight;
        }

        //Inserts Flight into Database
        public int InsertFlight(Flight flight)
        {
            //Inserts a number of seats based on numberOfSeats in the flights model
            string insertFlight = "INSERT INTO Flight (departureTime, arrivalTime, departureLocation," +
                                  "destination, modelId) VALUES(@departureTime, @arrivalTime, @departureLocation, @destination, @modelId)" +
                                  "SELECT SCOPE_IDENTITY()";
            int flightId;

            using (var scope = new TransactionScope())
            {
                //Open connection and write query string with placeholder parameters
                using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
                {
                    _con.Open();
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

                    var model = _modeldb.GetModelById(flight.Model);
                    var output = _seatdb.InsertMultipleSeats(model.NumberOfSeats, flightId, "default", 100.00);
                    
                    //Abort transaction if seats could not be entered
                    if (output != SuccessState.Success) return 0;
                }
                scope.Complete();
            }

            return flightId;
        }

        public SuccessState UpdateFlight(int flightNo, Flight flight)
        {
            string updateFlight = "UPDATE Flight SET departureTime = @departureTime, arrivalTime = @arrivalTime" +
                                  "departureLocation = @departureLocation, destination = @destination, modelId = @modelId WHERE flightId = @flightId";
            int result;
            
            //Open new connection and write query wit placeholder values
            using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
            {
                _con.Open();
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

            }

            //Return success state based on number of rows changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }
    }
}
