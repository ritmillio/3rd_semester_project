using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class ReservationDb : IReservationDb
    {
        private SqlConnectionStringBuilder _conStringBuilder = new SqlConnectionStringBuilder();
        private SqlConnection _con;
        private ISeatDb _seatDb;
    
        public ReservationDb()
        {
            _conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            _conStringBuilder.DataSource = "kraka.ucn.dk";
            _conStringBuilder.UserID = "dmaa0918_1071480";
            _conStringBuilder.Password = "Password1!";
            this._seatDb = new SeatDb();
        }

        private Reservation ObjectBuilder(SqlDataReader dataReader)
        {
            Reservation reservation = new Reservation(dataReader.GetInt32(2));
            return reservation;
        }

        public SuccessState DeleteReservation(int bookingNo)
        {
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            int result;

            //relationDB.DeleteRelationByBookingNo(bookingNo, con);

            string deleteReservation = "DELETE FROM Reservation WHERE bookingNo = @bookingNo";
            
            using(var command = new SqlCommand(deleteReservation, _con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                result = command.ExecuteNonQuery();
            }
            _con.Dispose();
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        public List<Reservation> GetAllReservations()
        {
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            var reservations = new List<Reservation>();
            string getAllReservations = "SELECT * FROM Reservation";
            _con.Open();

            using (var command = new SqlCommand(getAllReservations, _con))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    reservations.Add(ObjectBuilder(dataReader));
                }
            }
            _con.Dispose();
            return reservations;
        }

        public Reservation GetReservationById(int bookingNo)
        {
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string getReservation = "SELECT * FROM Reservation WHERE bookingNo = @bookingNo";
            Reservation reservation = null;
            using(var command = new SqlCommand(getReservation, _con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                var dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    reservation = ObjectBuilder(dataReader);
                }
            }
            _con.Dispose();
            return reservation;
        }

        // Create a reservation, update affected seats
        public int InsertReservation(Reservation reservation, List<string> seatIds)
        {
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            int bookingNo;
            string insertReservation = "INSERT INTO Reservation(price, customerId)" +
                "VALUES(@price, @customerId)" + "SELECT SCOPE_IDENTITY()";
            using(var command = new SqlCommand(insertReservation, _con))
            {
                command.Parameters.AddWithValue("@price", reservation.Price);
                command.Parameters.AddWithValue("@customerId", reservation.CustomerId);
                var result = command.ExecuteScalar();
                var resultString = result.ToString();
                bookingNo = int.Parse(resultString);
            }

            foreach (var seatId in seatIds)
            {
                var seat = _seatDb.GetSeatById(seatId);
                if (seat == null)
                {
                    return 0;
                }
                seat.BookingNo = bookingNo;
                _seatDb.UpdateSeat(seatId, seat);
            }
            
            return bookingNo;

        }

        public SuccessState UpdateReservation(int bookingNo, Reservation reservation)
        {
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            int result;
            string insertReservation = "UPDATE Reservation SET numberOfSeats = @numberOfSeats, price = @price WHERE bookingNo = @bookingNo";
            using (var command = new SqlCommand(insertReservation, _con))
            {
                command.Parameters.AddWithValue("@bookingNo", reservation.BookingNo);
                command.Parameters.AddWithValue("@price", reservation.Price);
                result = command.ExecuteNonQuery();
            }
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }
    }
}
