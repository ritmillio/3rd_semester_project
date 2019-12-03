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
            
            return cust;
        }


        public SuccessState DeleteCustomer(int customerId)
        {
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteCustomer = "DELETE FROM Customer WHERE customerId = @customerId";
            int result = 0;
            using(SqlCommand command = new SqlCommand(deleteCustomer, con))
            {
                //Replace placeholder value and execute query
                command.Parameters.AddWithValue("@customerId", customerId);
                result = command.ExecuteNonQuery();
            }
            //Return SuccessState based on amount of rows changed in DB
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
            //Open connection and write query string
            con = new SqlConnection(conStringBuilder.ConnectionString);
            List<Customer> customers = new List<Customer>();
            string getAllCustomers = "SELECT * FROM Customer";
            con.Open();

            using (SqlCommand command = new SqlCommand(getAllCustomers, con))
            {
                //Execute SqlDataReader and build object
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
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            Customer cust = null;
            string getCustomer = "SELECT * FROM Customer WHERE customerId = @customerId";
            using(SqlCommand command = new SqlCommand(getCustomer, con))
            {
                //Replace placeholder value and execute SqlDataReader. Build object.
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

        public int InsertCustomer(Customer cust)
        {
            //Open connection and write query with placeholder values
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int cust_id = 0;
            string insertCustomer = "INSERT INTO Customer(customerName, isAdmin) " +
                "VALUES( @customerName, @isAdmin) SELECT SCOPE_IDENTITY()";
            using(SqlCommand command = new SqlCommand(insertCustomer, con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@customerName", cust.Name);
                command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);

                Console.WriteLine("running");
                var result = command.ExecuteScalar();
                Console.WriteLine(result);
                Console.WriteLine(result.ToString());
                var resultString = result.ToString();
                cust_id = int.Parse(resultString);
            }

            con.Dispose();
            return cust_id;
        }

        public SuccessState UpdateCustomer(int customerId, Customer cust)
        {
            //Open connection and write query with placeholder values
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            int result = 0;
            string updateCustomer = "UPDATE Customer SET customerName = @customerName, isAdmin = @isAdmin WHERE customerId = @customerId";
            using (SqlCommand command = new SqlCommand(updateCustomer, con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@customerId", cust.CustomerID);
                command.Parameters.AddWithValue("@customerName", cust.Name);
                command.Parameters.AddWithValue("@isAdmin", cust.IsAdmin);
                result = command.ExecuteNonQuery();
            }
            //Return SuccessState based on amount of rows that were changed in DB
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
