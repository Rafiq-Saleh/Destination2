using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Destination2.WebUi.Search.Entities
{
    public class SearchForm
    {
        [DisplayName("From Airport")]
        public Dictionary<string, string> CityAirportListFrom { set; get; }
        [DisplayName("To Airport")]
        public Dictionary<string, string> CityAirportListTo  { set; get; }
    [DisplayName ("package")]
       
        public string IsPackage { set; get; }

        public string SearchType { set; get; }
        public string DepartureAirportID { set; get; }
        public string DestinationAirportID { set; get; }
        public string DepartureDate { set; get; }
        public string ReturnDate { set; get; }
        public string NumberOfAdults { set; get; }
        public string NumberOfChildren { set; get; }
        public string NumberOfInfants { set; get; }
        public string CabinClassID { set; get; }
        public string DirectFlightsOnly { set; get; }

        public SearchForm()
        {
            this.CityAirportListFrom = new Dictionary<string, string>();
            this.CityAirportListTo = new Dictionary<string, string>();
            this.CityAirportListFrom.Add("Liverpool", "LVL");
            this.CityAirportListFrom.Add("Manchester", "MAN");
            CityAirportListTo = this.CityAirportListFrom;

        }

        public Dictionary<string, string> GetAirportList()
        {
            
            return this.CityAirportListFrom;
        }
        }
    }
    
