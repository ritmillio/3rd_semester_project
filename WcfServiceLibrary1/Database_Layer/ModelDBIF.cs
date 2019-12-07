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
        SuccessState InsertModel(Model model);
        Model GetModelById(string modelId);
        SuccessState DeleteModelById(string modelId);
        SuccessState UpdateModel(string modelID, Model model);

    }
}