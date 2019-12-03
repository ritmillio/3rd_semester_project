﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    class CustomerReservationRelationDB : CustomerReservationRelationDBIF
    {
        public SuccessState DeleteRelationByCustomerId(int customerId, SqlConnection con)
        {
            string deleteRelation = "DELETE FROM ReservationCustomerRelation WHERE customerId = @customerId";
            using (SqlCommand command = new SqlCommand(deleteRelation, con))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
                int result = command.ExecuteNonQuery();
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

        public SuccessState DeleteRelationByBookingNo(int bookingNo, SqlConnection con)
        {
            string deleteRelation = "DELETE FROM ReservationCustomerRelation WHERE bookingNo = @bookingNo";
            using(SqlCommand command = new SqlCommand(deleteRelation, con))
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

        public string GetBookingNoByCustomerId(int customerId, SqlConnection con)
        {
            string getRelation = "SELECT * FROM ReservationCustomerRelation WHERE customerId = @customerId";
            using (SqlCommand command = new SqlCommand(getRelation, con))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    return dataReader.GetString(0);
                }
                return "";
            }
        }

        public string GetCustomerIdByBookingNo(int bookingNo, SqlConnection con)
        {
            string getRelation = "SELECT * FROM ReservationCustomerRelation WHERE bookingNo = @bookingNo";
            using(SqlCommand command = new SqlCommand(getRelation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    return dataReader.GetString(1);
                }
                return "";
            }
        }

        public SuccessState InsertRelation(int bookingNo, int customerId, SqlConnection con)
        {
            string insertRelation = "INSERT INTO ReservationCustomerRelation(bookingNo, customerId) " +
                "VALUES(@bookingNo, @customerId)";
            using (SqlCommand command = new SqlCommand(insertRelation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                command.Parameters.AddWithValue("@customerId,", customerId);
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
    }
}
