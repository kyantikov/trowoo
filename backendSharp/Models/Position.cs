using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trowoo.Models
{
    public class Position
    {
        public int Id {get; set;}
        [Required]
        public DateTime OpenedDate {get; set;}
        [Required]
        public decimal Cost {get; set;}
        public Security Security {get; set;}
    }
}