using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        public string ProfileImage { get; set; }
        public string PassportImage { get; set; }
        public string FullName { get; set; }
        public string email { get; set; }
        public string PhoneNumber { get; set; }
        public string ExtraPhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string City { get; set; }
        public string status { get; set; }
        public string ReportStaus { get; set; }
        public string rating { get; set; }
        public string Password { get; set; }
        public string notify { get; set; }
        public string accounttype { get; set; }
        public string address { get; set; }
        public string Reason { get; set; }


    }
}
