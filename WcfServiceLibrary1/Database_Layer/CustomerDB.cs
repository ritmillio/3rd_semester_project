using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class CustomerDb : ICustomerDb
    {
        private SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();

        public CustomerDb()
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
            var cust = new Customer(dataReader.GetString(1), dataReader.GetBoolean(2))
            {
                CustomerId = dataReader.GetInt32(0)
            };

            return cust;
        }


        //Delete customer given customer ID
        public SuccessState DeleteCustomer(int customerId)
        {
            string deleteCustomer = "DELETE FROM Customer WHERE customerId = @customerId";
            int result;
            
            //Open connection and write query with placeholder value
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(deleteCustomer, con))
                {
                    //Replace placeholder value and execute query
                    command.Parameters.AddWithValue("@customerId", customerId);
                    result = command.ExecuteNonQuery();
                }
            }

            //Return SuccessState based on amount of rows changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }

        //Returns a list of all customers in the database
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            string getAllCustomers = "SELECT * FROM Customer";
            
            //Open connection and write query string
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();

                using (var command = new SqlCommand(getAllCustomers, con))
                {
                    //Execute SqlDataReader and build object
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        customers.Add(ObjectBuilder(dataReader));
                    }
                }
            }
            return customers;
        }

        //Returns a customer object based on customerID
        public Customer GetCustomerById(int customerId)
        {
            Customer cust = null;
            string getCustomer = "SELECT * FROM Customer WHERE customerId = @customerId";
            
            //Open connection and write query with placeholder value
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(getCustomer, con))
                {
                    //Replace placeholder value and execute SqlDataReader. Build object.
                    command.Parameters.AddWithValue("@customerId", customerId);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        cust = ObjectBuilder(dataReader);
                    }
                }
            }
            return cust;
        }

        //Create a new customer
        public int InsertCustomer(Customer cust)
        {
            int custId;
            string insertCustomer = "INSERT INTO Customer(customerName, isAdmin) " +
                "VALUES( @customerName, @isAdmin) SELECT SCOPE_IDENTITY()";
            
            //Open connection and write query with placeholder values
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(insertCustomer, con))
                {
                    //Replace placeholder values and execute query
                    command.Parameters.AddWithValue("@customerName", cust.Name);
                    command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);

                    var result = command.ExecuteScalar().ToString();
                    custId = int.Parse(result);
                }
            }
            return custId;
        }

        public SuccessState UpdateCustomer(int customerId, Customer cust)
        {
            int result;
            string updateCustomer = "UPDATE Customer SET customerName = @customerName, isAdmin = @isAdmin WHERE customerId = @customerId";
            
            //Open connection and write query with placeholder values
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(updateCustomer, con))
                {
                    //Replace placeholder values and execute query
                    command.Parameters.AddWithValue("@customerId", cust.CustomerId);
                    command.Parameters.AddWithValue("@customerName", cust.Name);
                    command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);
                    result = command.ExecuteNonQuery();
                }
            }
            
            //Return SuccessState based on amount of rows that were changed in DB
            return result == 1 ? SuccessState.Success : SuccessState.DbUnreachable;
        }
    }
}
