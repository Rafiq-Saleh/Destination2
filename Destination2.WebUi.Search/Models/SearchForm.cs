using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Destination2.WebUi.Search.Models
{
    public class SearchForm
    {
        [DisplayName("Departing From")]
        public string DepartureAirportCode { get; set; }

        public string DepartureAirportText { get; set; }
        public IEnumerable<SelectListItem> AirportList { set; get; }

        [DisplayName("Going To")]
        public string DepartureAirport { get; set; }

        public IEnumerable<SelectListItem> AirportList2 { set; get; }


    }
}