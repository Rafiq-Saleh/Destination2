using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Destination2.Services.Flights.Entities
{
    [DataContract]
    public class FlightSearchResult
    {
        [DataMember]
        public FlightSearch FlightSearch { get; set; }

        [DataMember]
        public int FlightSearchId{get;set;}

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}