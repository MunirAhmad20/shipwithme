using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class Citylist
    {
        [Key]
        public int Id { get; set; }
        public string country { get; set; }

        public string City { get; set; }
        public string Status { get; set; }
    }
}
