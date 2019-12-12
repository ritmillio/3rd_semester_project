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
            //Instantiate proxies
            proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            proxy2 = new ServiceReference2.ReservationServiceIFClient();
            //Service call to get all seats on a flight
            seats = proxy.GetAllSeats(flightId);
            //Configure ListBox settings
            listBox1.MultiColumn = true;
            listBox1.Sorted = true;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            ListSeats();  
        }

        private void ListSeats()
        {
            
            //Lists every seat that has not been reserved
            foreach (var seat in seats)
            {
               if(seat.BookingNo == 0)
                {
                    listBox1.Items.Add(seat.SeatId);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            List<ServiceReference2.Seat> selectedSeats = new List<ServiceReference2.Seat>();

            foreach(var cell in listBox1.SelectedItems)
            {
                //Get the seat where the seat id is equal to the cell seat id... throw exception if seat not found
                //Convert seat to ServiceReference2.Seat so that it can be passed as a parameter to proxy2's methods

                var seat = (seats.Single(s => s.SeatId == cell.ToString()));
                var seat2 = new ServiceReference2.Seat
                {
                    SeatId = seat.SeatId,
                    BookingNo = seat.BookingNo,
                    FlightId = seat.FlightId,
                    Price = seat.Price,
                    Type = seat.Type
                };

                selectedSeats.Add(seat2);
            }
            //Makes a service call to create a new reservation with the selected seats
            
           //Must select at least one seat to create a reservation
           if(selectedSeats.Count >= 1)
            {
                int bookingNo = proxy2.NewReservation(selectedSeats);

                //Creates and shows message with booking confirmation and details
                string confirmationMessage = "Your Reservation has been booked." +
                    "\nBooking Number: " + bookingNo;

                foreach (var seat in selectedSeats)
                {
                    confirmationMessage += "\nSeat Number: " + seat.SeatId;
                }
                MessageBox.Show(confirmationMessage);
                this.Close();
                Form1 form = new Form1();
                form.Show();
            }
            
        }

        //Clears all seats selected by the user.
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }
    }
}
