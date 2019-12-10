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
            listBox1.Sorted = true;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            ListSeats();  
        }

        private void ListSeats()
        {
            foreach (var seat in seats)
            {
               listBox1.Items.Add(seat.SeatId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ServiceReference1.Seat> selectedSeats = new List<ServiceReference1.Seat>();

            foreach(var cell in listBox1.SelectedItems)
            {
                // Get the seat where the seat id is equal to the cell seat id... throw exception if seat not found
                selectedSeats.Add(seats.Single(s => s.SeatId == cell.ToString()));
            }

            //proxy2.NewReservation(selectedSeats, 1);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }
    }
}
