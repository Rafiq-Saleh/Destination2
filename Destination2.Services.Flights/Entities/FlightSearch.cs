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

        [DataMember]
        public int DepartureAirportID { get; set; }

        [DataMember]
        public int DestinationAirportID { get; set; }

        [DataMember]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public DateTime ReturnDate { get; set; }

        [DataMember]
        public int NumberOfAdults { get; set; }

        [DataMember]
        public int NumberOfChildren { get; set; }

        [DataMember]
        public int NumberOfInfants { get; set; }         

        [DataMember]
        public int AirlineClassID { get; set; }

        [DataMember]
        public bool SearchDirectOnly { get; set; }



        // this is the search object this need to have passengers etc in it
    }
}