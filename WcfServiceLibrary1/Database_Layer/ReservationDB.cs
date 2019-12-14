using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class ReservationDb : IReservationDb
    {
        private SqlConnection _con;
        private readonly SqlConnectionStringBuilder _conStringBuilder = new SqlConnectionStringBuilder();
        private readonly ISeatDb _seatDb;

        public ReservationDb()
        {
            _conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            _conStringBuilder.DataSource = "kraka.ucn.dk";
            _conStringBuilder.UserID = "dmaa0918_1071480";
            _conStringBuilder.Password = "Password1!";
            _seatDb = new SeatDb();
        }

        public SuccessState DeleteReservation(int bookingNo)
        {
            int result;
            var deleteReservation = "DELETE FROM Reservation WHERE bookingNo = @bookingNo";

            using (var scope = new TransactionScope())
            {
                using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
                {
                    _con.Open();
                    var seats = _seatDb.GetSeatByBookingNo(bookingNo);
                    foreach (var seat in seats)
                    {
                        var output = _seatDb.UpdateSeat(seat, true);
                        if (output == SuccessState.Success) continue;
                        return SuccessState.DbUnreachable;
                    }

                    using (var command = new SqlCommand(deleteReservation, _con))
                    {
                        command.Parameters.AddWithValue("@bookingNo", bookingNo);
                        result = command.ExecuteNonQuery();
                    }

                    if (result != 1) return SuccessState.DbUnreachable;
                }
                scope.Complete();
            }

            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        public List<Reservation> GetAllReservations()
        {
            var getAllReservations = "SELECT * FROM Reservation";
            var reservations = new List<Reservation>();
            using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
            {
                _con.Open();

                using (var command = new SqlCommand(getAllReservations, _con))
                {
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read()) reservations.Add(ObjectBuilder(dataReader));
                }
            }
            return reservations;
        }

        public Reservation GetReservationById(int bookingNo)
        {
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            var getReservation = "SELECT * FROM Reservation WHERE bookingNo = @bookingNo";
            Reservation reservation = null;
            using (var command = new SqlCommand(getReservation, _con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                var dataReader = command.ExecuteReader();
                if (dataReader.Read()) reservation = ObjectBuilder(dataReader);
            }

            _con.Dispose();
            return reservation;
        }

        // Create a reservation, update affected seats
        public int InsertReservation(Reservation reservation, List<Seat> seats)
        {
            int bookingNo;
            var insertReservation = "INSERT INTO Reservation(price, customerId)" +
                                    "VALUES(@price, @customerId)" + "SELECT SCOPE_IDENTITY()";

            using (var scope = new TransactionScope())
            {
                using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
                {
                    _con.Open();
                    using (var command = new SqlCommand(insertReservation, _con))
                    {
                        command.Parameters.AddWithValue("@price", reservation.Price);
                        command.Parameters.AddWithValue("@customerId", reservation.CustomerId);
                        var result = command.ExecuteScalar();
                        var resultString = result.ToString();
                        bookingNo = int.Parse(resultString);
                    }

                    foreach (var seat in seats)
                    {
                        seat.BookingNo = bookingNo;
                        //Abort transaction if the seat is already booked
                        if (_seatDb.GetSeatById(seat.SeatId).BookingNo == bookingNo) return 0;
                        var result = _seatDb.UpdateSeat(seat);
                        if (result == SuccessState.Success) continue;
                        return 0;
                    }
                }
                scope.Complete();
            }

            return bookingNo;
        }

        public SuccessState UpdateReservation(int bookingNo, Reservation reservation)
        {
            int result;
            var insertReservation =
                "UPDATE Reservation SET numberOfSeats = @numberOfSeats, price = @price WHERE bookingNo = @bookingNo";
            
            using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
            {
                _con.Open();
                using (var command = new SqlCommand(insertReservation, _con))
                {
                    command.Parameters.AddWithValue("@bookingNo", reservation.BookingNo);
                    command.Parameters.AddWithValue("@price", reservation.Price);
                    result = command.ExecuteNonQuery();
                }

            }

            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        private Reservation ObjectBuilder(SqlDataReader dataReader)
        {
            var reservation = new Reservation(dataReader.GetInt32(2));
            return reservation;
        }
    }
}
