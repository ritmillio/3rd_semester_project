using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webgu.Pages
{
    public class ListOfFlightsModel : PageModel
    {
        public void OnGet()
        {

        }
        public List<ServiceReference1.Flight> GetFlights()
        {
            ServiceReference1.Flight_ControllerServiceIFClient proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            return proxy.ListActiveFlights();
        }
        public string CheckRadio(FormCollection frm)
        {
            string userInput = frm["Select"].ToString();
            return userInput;
        }
    }
}