using System.Data.SqlClient;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.Database_Layer
{
    public interface IModelDb
    {
        SuccessState InsertModel(Model model);
        Model GetModelById(string modelId, SqlConnection con = null);
        SuccessState DeleteModelById(string modelId);
        SuccessState UpdateModel(string modelId, Model model);

    }
}