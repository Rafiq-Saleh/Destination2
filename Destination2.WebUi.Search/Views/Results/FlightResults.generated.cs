﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Destination2.WebUi.Search;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Results/FlightResults.cshtml")]
    public partial class _Views_Results_FlightResults_cshtml : System.Web.Mvc.WebViewPage<Destination2.WebUi.Search.Models.FlightResultViewModel>
    {
        public _Views_Results_FlightResults_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Results\FlightResults.cshtml"
  
    ViewBag.Title = "FlightResults";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h1>FlightResults</h1>\r\n<h2>");

            
            #line 7 "..\..\Views\Results\FlightResults.cshtml"
Write(Model.Message);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\r\n");

            WriteLiteral("<table>  <thead> <tr> <th> Image </th> <th> Description </th> <th> Price </th> </tr></thead> " +
            "<tbody><tr><td>Atlantis The Palm - Dubai Beach</td><td> "+
                  "  The Legend of Atlantis is brought to life in modern day Dubai at this iconic resort.It is situated on its own beautiful, man - made island and has unique architecture which is breathtaking to behold.If you’re looking for a five star hotel in Dubai, look no further. "+
                "</td><td>£310.96</td></tr></tbody></table> ");

        }
    }
}
#pragma warning restore 1591
