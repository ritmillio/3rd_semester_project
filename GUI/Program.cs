using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            ServiceReference1.Flight_ControllerServiceIFClient proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            ServiceReference2.ReservationServiceIFClient proxy2 = new ServiceReference2.ReservationServiceIFClient();
        }
    }
}
