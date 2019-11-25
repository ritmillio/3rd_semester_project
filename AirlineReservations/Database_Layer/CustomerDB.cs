using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    public class CustomerDB : CustomerDBIF
    {
        private SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();
        private SqlConnection con;

        public CustomerDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        //Builds Customer Objects for GetCustomerById and GetAllCustomers
        private Customer ObjectBuilder(SqlDataReader dataReader)
        {
            //Takes values from SqlDataReader and puts them into a Customer object
            Customer cust = new Customer(dataReader.GetString(1), dataReader.GetBoolean(2));
            cust.CustomerID = dataReader.GetInt32(0);
            AddBookingNoToCustomerObject(cust);
            
            return cust;
        }

        //A customer's bookingNo is stored in a many-to-many relation table which is pulled here
        private Customer AddBookingNoToCustomerObject(Customer cust)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getReservationIds = "SELECT bookingNo FROM ReservationCustomerRelation WHERE customerId = @customerId";

            using (SqlCommand command = new SqlCommand(getReservationIds, con))
            {
                command.Parameters.AddWithValue("@customerId", cust.CustomerID);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    cust.AddBookingNo(dr.GetString(0));
                }
            }
            return cust;
        }
        public SuccessState DeleteCustomer(int customerId)
        {
            FlightDBIF flightdb = new FlightDB();

            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteCustomer = "DELETE FROM Customer WHERE customerId = @customerId";
            int result = 0;
            using(SqlCommand command = new SqlCommand(deleteCustomer, con))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
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

        public List<Customer> GetAllCustomers()
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            List<Customer> customers = new List<Customer>();
            string getAllCustomers = "SELECT * FROM Customer";
            con.Open();

            using (SqlCommand command = new SqlCommand(getAllCustomers, con))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    customers.Add(ObjectBuilder(dataReader));
                }
                return customers;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            Customer cust = null;
            string getCustomer = "SELECT * FROM Customer WHERE customerId = @customerId";
            using(SqlCommand command = new SqlCommand(getCustomer, con))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    cust = ObjectBuilder(dataReader);
                }
                
            }
            con.Dispose();
            return cust;
        }

        public SuccessState InsertCustomer(Customer cust)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string insertCustomer = "INSERT INTO Customer(customerName, isAdmin) " +
                "VALUES( @customerName, @isAdmin)";
            using(SqlCommand command = new SqlCommand(insertCustomer, con))
            {
                command.Parameters.AddWithValue("@customerName", cust.Name);
                command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);
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

        public SuccessState AddReservationToCustomer(int customerId, string bookingNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string insertReservationRelation = "INSERT INTO ReservationCustomerRelation(bookingNo, customerId) " +
                "VALUES(@bookingNo, @customerId)";
            using(SqlCommand command = new SqlCommand(insertReservationRelation, con))
            {
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                command.Parameters.AddWithValue("@customerId", customerId);
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

        public SuccessState UpdateCustomer(int customerId, Customer cust)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string updateCustomer = "UPDATE Customer SET customerName = @customerName, isAdmin = @isAdmin WHERE customerId = @customerId";
            using (SqlCommand command = new SqlCommand(updateCustomer, con))
            {
                command.Parameters.AddWithValue("@customerId", cust.CustomerID);
                command.Parameters.AddWithValue("@customerName", cust.Name);
                command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);
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
