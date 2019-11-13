using System;
using System.Data.SqlClient;
using Model_Layer;

namespace Database_Layer
{
    public interface PlaneModelDBIF
    {
        public void insertVoid(Model planeModel);

    }

}

