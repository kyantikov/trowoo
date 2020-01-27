using System;
using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;

namespace Trowoo.Models
{
    public class Security
    {
        public int Id {get; set;}
        public string Ticker {get; set;}
        public string Name {get; set;}
        public List<Quote> Quotes {get; set;}
    }
}