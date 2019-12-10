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
    public partial class Form1 : Form
    {
        ServiceReference1.Flight_ControllerServiceIFClient proxy;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<ServiceReference1.Flight> flights = proxy.ListActiveFlights();
            foreach (var flight in flights)
            {
                dataGridView1.Rows.Add(flight.DepartureLocation, flight.Destination, flight.DepartureTime, flight.ArrivalTime , (flight.FlightNo));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string flightIdString = dataGridView1.CurrentCell.Value.ToString();
            int flightId = Convert.ToInt32(flightIdString);
            Form2 newform = new Form2(flightId);
            this.Hide();
            newform.ShowDialog();

        }
    }
}
