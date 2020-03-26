using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trowoo.Models
{
    public class Portfolio
    {
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string UserId {get; set;}
        public List<Position> Positions {get; set;} = new List<Position>();
    }
}