using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class weight
    {

        [Key]
        public int Id { get; set; }

        public string weightlimit { get; set; }
    
        public string Status { get; set; }
    }
}
