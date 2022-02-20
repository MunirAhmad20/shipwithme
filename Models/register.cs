using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class register
    {
        [Key]
        public int Id { get; set; }
   
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string address { get; set; }
        public string zip_code { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string checkingaccount { get; set; }
        public string netspend { get; set; }
        public string deviceid { get; set; }
        public string devicetype { get; set; }
        public string Ipaddress { get; set; }
        public string forms { get; set; }
      
        public string date { get; set; }


    }
}
