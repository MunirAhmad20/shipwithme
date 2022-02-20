﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class Airportlist
    {
        [Key]
        public int Id { get; set; }

        public string Airport { get; set; }
        public string Status { get; set; }
    }
}
