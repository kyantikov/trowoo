using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trowoo.Models
{
    public class TrailingStop
    {
        public int Id {get; set;}
        [Required]
        public decimal Percent {get; set;}
        public Position Position {get; set;}

    }
}