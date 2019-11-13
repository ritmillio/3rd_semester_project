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
            con = new SqlConnection(conStringBuilder.ConnectionString);
        }

        public void DeleteModel(string modelId)
        {
            throw new NotImplementedException();
        }

        public Model GetModel(string modelId)
        {
            throw new NotImplementedException();
        }

        public void InsertModel(Model model)
        {
            throw new NotImplementedException();
        }

        public void updateModel(string modelID, Model model)
        {
            throw new NotImplementedException();
        }
    }
}
