using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class accountlimit
    {
        [Key]
        public int Id { get; set; }

        public string accounttitle { get; set; }
        public string accountlimits { get; set; }
        public string Status { get; set; }


    }
}
