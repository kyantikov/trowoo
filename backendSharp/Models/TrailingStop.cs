using System;
using System.Collections.Generic;

namespace backendSharp.Models
{
    public class TrailingStop
    {
        public int Id {get; set;}
        public decimal Percent {get; set;}
        public Position Position {get; set;}

    }
}