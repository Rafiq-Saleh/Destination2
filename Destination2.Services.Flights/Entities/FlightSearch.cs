using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations; 
namespace Destination2.Services.Flights.Entities
{
    [DataContract]
    public class FlightSearch
    {
        [DataType(DataType.Text)]
        [DataMember]
        public string SearchType { get; set; }

        [DataMember]
        [Required]
        [Display(Name ="Package")]
        public bool IsPackage { get; set; }

        [DataMember]
       
        public int DepartureAirportID { get; set; }

        [DataMember]
        public int DestinationAirportID { get; set; }

        [DataMember]
       
        [DataType(DataType.Date)]
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
        public int CabinClassID { get; set; }

        [DataMember]
        public bool DirectFlightsOnly { get; set; }



        // this is the search object this need to have passengers etc in it
    }
}