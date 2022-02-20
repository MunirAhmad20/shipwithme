using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }

        public string FlightDate { get; set; }
        public string AvailableWeight { get; set; }
   
       
        public string ToAirport { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string FromAirport { get; set; }
        public string FromCountry { get; set; }
        public string FromCity { get; set; }
        public string notify { get; set; }
        public string Reason { get; set; }


    }
}
