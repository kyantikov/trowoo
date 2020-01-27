using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trowoo.Models
{
    public class LowPrice
    {
        public int Id {get; set;}
        [Required]
        public decimal Price {get; set;}
        public Position Position {get; set;}
    }
}