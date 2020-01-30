using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Trowoo.Models
{
    public class TrailingStop
    {
        public int Id {get; set;}

        [Required]
        public decimal Percent {get; set;}

        [Required]
        [ForeignKey("PositionId")]
        public int PositionId {get; set;}

    }
}