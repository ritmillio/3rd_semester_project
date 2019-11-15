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
        void InsertModel(Model model);
        Model GetModelById(string modelId);
        void DeleteModelById(string modelId);
        void updateModel(string modelID, Model model);

    }
}