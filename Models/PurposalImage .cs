using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Models
{
    public class PurposalImage
    {
        [Key]
        public int Id { get; set; }
        public int purposalId { get; set; }
        public string PurposalImages { get; set; }

    }
}
