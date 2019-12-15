using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class ModelDb : IModelDb
    {
        private SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();

        public ModelDb()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        //Builds Model object with data from SqlDataReader
        private Model ObjectBuilder(SqlDataReader dataReader)
        {
            var model = new Model(dataReader.GetString(0), dataReader.GetInt32(1));
            return model;
        }

        public SuccessState DeleteModelById(string modelId)
        {
            string deleteModel = "DELETE FROM Model WHERE modelId = @modelId";
            int result;
            
            //Open connection and write query with placeholder value
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(deleteModel, con))
                {
                    //Replace placeholder value and execute query
                    command.Parameters.AddWithValue("@modelId", modelId);
                    result = command.ExecuteNonQuery();
                }

            }

            //Return SuccessState based on number of rows changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }

        public Model GetModelById(string modelId, SqlConnection con = null)
        {
            Model model = null;
            var newConFlag = false;
            string getModel = "SELECT * FROM Model WHERE modelId = @modelId";
            if (con == null)
            {
                con = new SqlConnection(conStringBuilder.ConnectionString);
                newConFlag = true;
            }


            //Open connection and write query with placeholder value
                con.Open();
                using (var command = new SqlCommand(getModel, con))
                {
                    //Replace placeholder value and execute SqlDataReader. Build and return object.
                    command.Parameters.AddWithValue("@modelId", modelId);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        model = ObjectBuilder(dataReader);
                    }
                }
                
            // Dispose the connection if it was created here
            if (newConFlag) con.Dispose();
            return model;
        }

        public SuccessState InsertModel(Model model)
        {
            string insertModel = "INSERT INTO Model(modelId, numberOfSeats) VALUES(@modelId, @numberOfSeats)";
            int result;
            
            //Open connection and write query with placeholder values
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(insertModel, con))
                {
                    //Replace placeholder values and execute query
                    command.Parameters.AddWithValue("@modelId", model.Id);
                    command.Parameters.AddWithValue("@numberOfSeats", model.NumberOfSeats);
                    result = command.ExecuteNonQuery();
                }

            }

            //Return SuccessState based on amount of rows that were changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }

        public SuccessState UpdateModel(string modelId, Model model)
        {
            string updateModel = "UPDATE Model SET numberOfSeats = @numberOfSeats WHERE modelId = @modelId";
            int result;
            
            //Open connection and write query with placeholder values
            using (var con = new SqlConnection(conStringBuilder.ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand(updateModel, con))
                {
                    //Replace placeholder values and execute query
                    command.Parameters.AddWithValue("numberOfSeats", model.NumberOfSeats);
                    result = command.ExecuteNonQuery();
                }

            }

            //Return SuccessState based on amount of rows that were changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }
    }
}
