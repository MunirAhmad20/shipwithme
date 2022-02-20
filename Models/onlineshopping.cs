using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class onlineshopping
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }
        public string Location { get; set; }
        public string TimeTo { get; set; }
        public string TimeFrom { get; set; }
        public string PaymentType { get; set; }
        public string Reward { get; set; }
        public string Days { get; set; }
        public string PackageOwner { get; set; }
        public string PassengerName { get; set; }
        public string url { get; set; }


    }
}
