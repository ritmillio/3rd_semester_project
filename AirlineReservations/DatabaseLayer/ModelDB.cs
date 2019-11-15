using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    class ModelDB : ModelDBIF
    {
        SqlConnectionStringBuilder conStringBuilder;
        SqlConnection con;

        public ModelDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        private Model objectBuilder(SqlDataReader dataReader)
        {
            Model model = null;
            if (dataReader.Read())
            {
                model = new Model(dataReader.GetString(0), dataReader.GetInt32(1));
            }
            
            return model;
        }

        public void DeleteModelById(string modelId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteModel = "DELETE * FROM Model WHERE modelId = @modelId";
            using(SqlCommand command = new SqlCommand(deleteModel, con))
            {
                command.Parameters.AddWithValue("@modelId", modelId);
                command.ExecuteNonQuery();
            }
            con.Dispose();
        }

        public Model GetModelById(string modelId)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getModel = "SELECT * FROM Model WHERE modelId = @modelId";
            using(SqlCommand command = new SqlCommand(getModel, con))
            {
                command.Parameters.AddWithValue("@modelId", modelId);
                SqlDataReader dataReader = command.ExecuteReader();
                if(objectBuilder(dataReader) != null)
                {
                    con.Dispose();
                    return objectBuilder(dataReader);
                }
            }
            con.Dispose();
            return null;
            
        }

        public void InsertModel(Model model)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string insertModel = "INSERT INTO Model(modelId, numberOfSeats) VALUES(@modelId, @numberOfSeats)";

            using (SqlCommand command = new SqlCommand(insertModel, con))
            {
                command.Parameters.AddWithValue("@modelId", model.Id);
                command.Parameters.AddWithValue("@numberOfSeats", model.NumberOfSeats);
                command.ExecuteNonQuery();
            }

            con.Dispose();
        }

        public void updateModel(string modelID, Model model)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string updateModel = "UPDATE Model SET numberOfSeats = @numberOfSeats WHERE modelId = @modelId";

            using(SqlCommand command = new SqlCommand(updateModel, con))
            {
                command.Parameters.AddWithValue("numberOfSeats", model.NumberOfSeats);
            }

            con.Dispose();
        }
    }
}
