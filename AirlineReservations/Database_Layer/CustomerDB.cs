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
            throw new NotImplementedException();
        }

        public CustomerDBIF GetCustomerById(string customerId)
        {
            throw new NotImplementedException();
        }

        public int InsertCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        public int UpdateCUstomer(string customerId, Customer cust)
        {
            throw new NotImplementedException();
        }
    }
}
