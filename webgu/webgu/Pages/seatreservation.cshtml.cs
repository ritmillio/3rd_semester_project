using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webgu
{
    public class seatreservationModel : PageModel
    {
        ServiceReference1.Flight_ControllerServiceIFClient proxy;
        List<ServiceReference1.Seat> seats;

        public seatreservationModel()
        {
            proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            //seats = proxy.GetAllSeats();
        }


        public void OnGet()
        {

        }
    }
}