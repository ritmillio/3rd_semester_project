using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form2 : Form
    {
        ServiceReference1.Flight_ControllerServiceIFClient proxy;
        ServiceReference2.ReservationServiceIFClient proxy2;
        List<ServiceReference1.Seat> seats;
        public Form2(int flightId)
        {
            InitializeComponent();
            listBox1.MultiColumn = true;
            proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            proxy2 = new ServiceReference2.ReservationServiceIFClient();
            seats = proxy.GetAllSeats(flightId);
            ListSeats();
        }

        private void ListSeats()
        {
            foreach (var seat in seats)
            {
               listBox1.Items.Add(seat.SeatId);
            }
        }
    }
}
