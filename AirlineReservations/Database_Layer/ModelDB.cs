using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public class ModelDb : IModelDb
    {
        private SqlConnectionStringBuilder _conStringBuilder = new SqlConnectionStringBuilder();
        private SqlConnection _con;

        public ModelDb()
        {
            _conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            _conStringBuilder.DataSource = "kraka.ucn.dk";
            _conStringBuilder.UserID = "dmaa0918_1071480";
            _conStringBuilder.Password = "Password1!";
        }

        //Builds Model object with data from SqlDataReader
        private Model ObjectBuilder(SqlDataReader dataReader)
        {
            var model = new Model(dataReader.GetString(0), dataReader.GetInt32(1));
            return model;
        }

        public SuccessState DeleteModelById(string modelId)
        {
            //Open connection and write query with placeholder value
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string deleteModel = "DELETE FROM Model WHERE modelId = @modelId";
            int result;
            using(var command = new SqlCommand(deleteModel, _con))
            {
                //Replace placeholder value and execute query
                command.Parameters.AddWithValue("@modelId", modelId);
                result = command.ExecuteNonQuery();
            }
            _con.Dispose();
            //Return SuccessState based on number of rows changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }

        public Model GetModelById(string modelId)
        {
            Model model = null;
            //Open connection and write query with placeholder value
            using (_con = new SqlConnection(_conStringBuilder.ConnectionString))
            {
                
                _con.Open();
                string getModel = "SELECT * FROM Model WHERE modelId = @modelId";
                using (var command = new SqlCommand(getModel, _con))
                {
                    //Replace placeholder value and execute SqlDataReader. Build and return object.
                    command.Parameters.AddWithValue("@modelId", modelId);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        model = ObjectBuilder(dataReader);
                    }
                }
            }
            _con.Dispose();
            return model;
        }

        public SuccessState InsertModel(Model model)
        {
            //Open connection and write query with placeholder values
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string insertModel = "INSERT INTO Model(modelId, numberOfSeats) VALUES(@modelId, @numberOfSeats)";
            int result;
            using (var command = new SqlCommand(insertModel, _con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("@modelId", model.Id);
                command.Parameters.AddWithValue("@numberOfSeats", model.NumberOfSeats);
                result = command.ExecuteNonQuery();
            }
            _con.Dispose();
            //Return SuccessState based on amount of rows that were changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }

        public SuccessState UpdateModel(string modelId, Model model)
        {
            //Open connection and write query with placeholder values
            _con = new SqlConnection(_conStringBuilder.ConnectionString);
            _con.Open();
            string updateModel = "UPDATE Model SET numberOfSeats = @numberOfSeats WHERE modelId = @modelId";
            int result;
            using(var command = new SqlCommand(updateModel, _con))
            {
                //Replace placeholder values and execute query
                command.Parameters.AddWithValue("numberOfSeats", model.NumberOfSeats);
                result = command.ExecuteNonQuery();
            }
            _con.Dispose();
            //Return SuccessState based on amount of rows that were changed in DB
            return result == 0 ? SuccessState.DbUnreachable : SuccessState.Success;
        }
    }
}
