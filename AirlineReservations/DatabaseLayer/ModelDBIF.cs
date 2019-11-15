using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;

namespace AirlineReservations.DatabaseLayer
{
    public interface ModelDBIF
    {
        int InsertModel(Model model);
        Model GetModelById(string modelId);
        int DeleteModelById(string modelId);
        int updateModel(string modelID, Model model);

    }
}