using System;
using System.Collections.Generic;

namespace Trowoo.Models
{
    public class Quote
    {
        public int Id {get; set;}
        public DateTime QuoteDate {get; set;}
        public decimal Open {get; set;}
        public decimal Close {get; set;}
        public decimal High {get; set;}
        public decimal Low {get; set;}
        public decimal AdjustedClose {get; set;}
        public int Volume {get; set;}
        public decimal DividendAmount {get; set;}
        public decimal SplitCoefficient {get; set;}
        public Security Security {get; set;}
    }
}