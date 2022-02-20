using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class customernotifications
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string post { get; set; }
        public string Gmail { get; set; }
        public string type { get; set; }
        public string status { get; set; }
       

    }
}
