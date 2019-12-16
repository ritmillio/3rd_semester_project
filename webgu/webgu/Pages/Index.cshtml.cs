using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webgu.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
           
        }
        public List<ServiceReference1.Flight> GetFlights()
        {
            ServiceReference1.Flight_ControllerServiceIFClient proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            return proxy.ListActiveFlights();
        }
        public void getUserInput()
        {
            var userInput = Request.Form["submit"];
            
        }
        
    }
}
