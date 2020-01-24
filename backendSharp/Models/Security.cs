using System;
using System.ComponentModel.DataAnnotations;

namespace backendSharp.Models
{
    public class Security
    {
        public long Id {get; set;}
        public string Ticker {get;set;}
        public string Name {get;set;}
    }
}