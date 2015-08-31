using System;
using System.Runtime.Serialization;

namespace Destination2.Services.Flights.Entities
{
    [DataContract]
    public class FlightSearch
    {
        [DataMember]
        public string SearchType { get; set; }

        [DataMember]
        public bool IsPackage { get; set; }
        
        // this is the search object this need to have passengers etc in it
    }
}