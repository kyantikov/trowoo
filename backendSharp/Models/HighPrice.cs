using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Trowoo.Models
{
    public class HighPrice
    {
        public int Id {get; set;}
        [Required]
        public decimal Price {get; set;}
        [Required]
        [ForeignKey("PositionId")]
        public int PositionId {get; set;}
    }
}