using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class Adminlogin
    {
        [Key]
        public int Id { get; set; }
      
        public string Username { get; set; }
        public string Gmail { get; set; }
        public string systemroll { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string Reason { get; set; }


    }
}
