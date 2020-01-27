using System;
using System.Collections.Generic;

namespace Trowoo.Models
{
    public class Portfolio
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string UserId {get; set;}
        public List<Position> Positions {get; set;}
    }
}