#pragma checksum "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfb95678ac29b442658760083d54c87d492c13de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(webgu.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace webgu.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\_ViewImports.cshtml"
using webgu;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfb95678ac29b442658760083d54c87d492c13de", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"995684b360aca09dbdc0d5a4eb6aa883c77b0208", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
  
    List<ServiceReference1.Flight> flights;
    flights = Model.GetFlights();


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""text-center"">
    <div class=""display-flights"">
        <table>
            <tr>
                <th>Departure</th>
                <th>Arrival</th>
                <th>Departure Time</th>
                <th>Arrival Time</th>
                <th>FLight ID</th>
            </tr>
            <tr>
");
#nullable restore
#line 23 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                 foreach (var flight in flights)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>");
#nullable restore
#line 25 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                   Write(flight.DepartureLocation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 26 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                   Write(flight.Destination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 27 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                   Write(flight.DepartureTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 28 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                   Write(flight.ArrivalTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 29 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                   Write(flight.FlightNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th><input type=\"radio\" name=\"submit\" value=\"flight\" />Select Flight</th>\r\n");
#nullable restore
#line 31 "C:\Users\PhilipBraarup\Desktop\3rdSemProjV4\DataScience3rdSemesterProjectGroup3\webgu\webgu\Pages\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </table>\r\n        <div class=\"next-button\">\r\n        </div>\r\n        <a href=\"seatreservation.cshtml\">Test</a>\r\n        \r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591