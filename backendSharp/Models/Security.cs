using System;
using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;

namespace backendSharp.Models
{
    public class Security
    {
        public long Id {get; set;}
        public string Ticker {get; set;}
        public string Name {get; set;}
        public List<Quote> Quotes {get; set;}
    }
}