using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webgu
{
    public class showflightsModel : PageModel
    {
        public ServiceReference1.Flight_ControllerServiceIFClient proxy  = new ServiceReference1.Flight_ControllerServiceIFClient();
       
        public void OnGet()
        {
            
        }
        public List<ServiceReference1.Flight> GetFlights()
        {
            ServiceReference1.Flight_ControllerServiceIFClient proxy = new ServiceReference1.Flight_ControllerServiceIFClient();
            return proxy.ListActiveFlights();
        }
    }
}