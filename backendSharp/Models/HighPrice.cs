using System;
using System.Collections.Generic;

namespace Trowoo.Models
{
    public class HighPrice
    {
        public int Id {get; set;}
        public decimal Price {get; set;}
        public Position Position {get; set;}
    }
}