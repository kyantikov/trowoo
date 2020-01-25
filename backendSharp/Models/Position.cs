using System;
using System.Collections.Generic;

namespace backendSharp.Models
{
    public class Position
    {
        public int Id {get; set;}
        public DateTime OpenedDate {get; set;}
        public decimal Cost {get; set;}
        public Security Security {get; set;}
    }
}