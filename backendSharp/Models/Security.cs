using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trowoo.Models
{
    public class Security
    {
        public int Id {get; set;}
        [Required]
        [RegularExpression(@"[A-Z]{3,}", ErrorMessage= "Ticker must be all uppercase.")]
        public string Ticker {get; set;}
        [Required]
        public string Name {get; set;}
        public List<Quote> Quotes {get; set;} = new List<Quote>();

        public void AddQuotes(List<Quote> quotes)
        {
            Quotes.AddRange(quotes);
        }
    }
}