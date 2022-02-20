using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class reasonlist
    {
        [Key]
        public int Id { get; set; }

        public string reasons { get; set; }
        public string Status { get; set; }
    }
}
