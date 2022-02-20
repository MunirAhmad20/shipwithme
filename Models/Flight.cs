using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        public string FlightDate { get; set; }
        public string ArivalDate { get; set; }
        public string AvailableWeight { get; set; }
        public string IsNegotionable { get; set; }
       
        public string ToAirport { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string FromAirport { get; set; }
        public string FromCountry { get; set; }
        public string FromCity { get; set; }

        public string PricePerKG { get; set; }
        public string Currency { get; set; }
        public string PrefferedPickupDestination { get; set; }
        public string PrefferedDeliveryDestination { get; set; }
        public string PrefferedDeliveryTimeAfterArival { get; set; }
        public string PrefferedPackageType { get; set; }
        public string PassengerName { get; set; }
        public string FlightStatus { get; set; }
        public string numberofpurposals { get; set; }
        public string notify { get; set; }
        public string Reason { get; set; }

    }
}
