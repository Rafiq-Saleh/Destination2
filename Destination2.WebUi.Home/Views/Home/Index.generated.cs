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
    using Destination2.WebUi.Home;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class _Views_Home_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Index";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Index</h2>\r\nThis is from the module\r\n\r\n<p></p>\r\n");

            
            #line 10 "..\..\Views\Home\Index.cshtml"
Write(Html.Partial("~/views/partials/SearchForm.cshtml"));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
