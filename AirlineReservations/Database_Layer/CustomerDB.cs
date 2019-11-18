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
    class CustomerDB : CustomerDBIF
    {
        private SqlConnectionStringBuilder conStringBuilder;
        private SqlConnection con;

        public CustomerDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        private Customer ObjectBuilder(SqlDataReader dataReader)
        {
            Customer cust = new Customer(dataReader.GetString(1), dataReader.GetBoolean(2), dataReader.GetString(0));
            return cust;
        }
        public int DeleteCustomer(string customerId)
        {
            FlightDBIF flightdb = new FlightDB();

            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteCustomer = "DELETE * FROM Customer WHERE customerId = @customerId";
            int result = 0;
            using(SqlCommand command = new SqlCommand(deleteCustomer, con))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
                result = command.ExecuteNonQuery();
            }
            if(result == 1)
            {
                con.Dispose();
                return (int)SqlResult.Success;
            } else
            {
                con.Dispose();
                return (int)SqlResult.Failure;
            }
        }

        public ArrayList GetAllCustomers()
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            ArrayList customers = new ArrayList();
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

        public Customer GetCustomerById(string customerId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            Customer cust = null;
            string getCustomer = "SELECT * FROM Customer WHERE customerId = @customerId";
            using(SqlCommand command = new SqlCommand(getCustomer, con))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
                SqlDataReader dataReader = command.ExecuteReader();
                cust = ObjectBuilder(dataReader);
            }
            con.Dispose();
            return cust;
        }

        public int InsertCustomer(Customer cust)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string insertCustomer = "INSERT INTO Customer(customerId, customerName, isAdmin) " +
                "VALUES(@customerId, @customerName, @isAdmin)";
            using(SqlCommand command = new SqlCommand(insertCustomer, con))
            {
                command.Parameters.AddWithValue("@customerId", cust.CustomerID);
                command.Parameters.AddWithValue("@customerName", cust.Name);
                command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);
                result = command.ExecuteNonQuery();
            }
            if(result == 1)
            {
                return (int)SqlResult.Success;
            } else
            {
                return (int)SqlResult.Failure;
            }
        }

        public int UpdateCUstomer(string customerId, Customer cust)
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
                return (int)SqlResult.Success;
            }
            else
            {
                return (int)SqlResult.Failure;
            }
        }
    }
}
