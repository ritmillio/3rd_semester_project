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
    public class ReservationDB : ReservationDBIF
    {
        SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();
        SqlConnection con;
        CustomerReservationRelationDB relationDB;
        public ReservationDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";

            relationDB = new CustomerReservationRelationDB();
        }

        private Reservation objectBuilder(SqlDataReader dataReader)
        {
            Reservation reservation = new Reservation(dataReader.GetString(0), dataReader.GetInt32(2));
            return reservation;
        }

        public SuccessState DeleteReservation(int bookingNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();

            relationDB.DeleteRelationByBookingNo(bookingNo, con);

            string deleteReservation = "DELETE *  FROM Reservation WHERE bookingNo = @bookingNo";
            
            using(SqlCommand command = new SqlCommand(deleteReservation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                int result = command.ExecuteNonQuery();
                if(result == 1)
                {
                    return SuccessState.Success;
                } else
                {
                    return SuccessState.DBUnreachable;
                }
                
            }
        }

        public ArrayList GetAllReservations()
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            ArrayList reservations = new ArrayList();
            string getAllReservations = "SELECT * FROM Reservation";
            con.Open();

            using (SqlCommand command = new SqlCommand(getAllReservations, con))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    reservations.Add(objectBuilder(dataReader));
                }
            }
            con.Dispose();
            return reservations;
        }

        public Reservation GetReservationById(int bookingNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getReservation = "SELECT * FROM Reservation WHERE bookingNo = @bookingNo";
            Reservation reservation = null;
            using(SqlCommand command = new SqlCommand(getReservation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    reservation = objectBuilder(dataReader);
                }
            }
            con.Dispose();
            return reservation;
        }

        public SuccessState InsertReservation(Reservation reservation)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string insertReservation = "INSERT INTO Reservation(bookingNo, numberOfSeats, price)" +
                "VALUES(@bookingNo, @numberOfSeats, @price)";
            using(SqlCommand command = new SqlCommand(insertReservation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", reservation.BookingNo);
                command.Parameters.AddWithValue("@numberOfSeats", reservation.NumberOfSeats);
                command.Parameters.AddWithValue("@price", reservation.Price);
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

        public SuccessState UpdateReservation(int bookingNo, Reservation reservation)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string insertReservation = "UPDATE Reservation SET numberOfSeats = @numberOfSeats, price = @price WHERE bookingNo = @bookingNo";
            using (SqlCommand command = new SqlCommand(insertReservation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", reservation.BookingNo);
                command.Parameters.AddWithValue("@numberOfSeats", reservation.NumberOfSeats);
                command.Parameters.AddWithValue("@price", reservation.Price);
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
    }
}
