using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class countrylist
    {
        [Key]
        public int Id { get; set; }

        public string Country{ get; set; }
        public string Status { get; set; }
    }
}
