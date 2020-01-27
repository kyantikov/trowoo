using System;
using System.Collections.Generic;

namespace Trowoo.Models
{
    public class LowPrice
    {
        public int Id {get; set;}
        public decimal Price {get; set;}
        public Position Position {get; set;}
    }
}