using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Trowoo.Models
{
    public class Quote : IEqualityComparer<Quote>
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

        public bool Equals(Quote quote1, Quote quote2)
        {
            return quote1?.QuoteDate == quote2?.QuoteDate;
        }
        public int GetHashCode(Quote quote)
        {
            return quote.QuoteDate.GetHashCode();
        }
        public override bool Equals(object quote)
        {
            return Equals(this, (Quote)quote);
        }
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
    }
}