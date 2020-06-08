using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trowoo.ViewModels;

namespace Trowoo.Models
{
    public class Position
    {
        public int Id {get; set;}
        [Required]
        public DateTime OpenedDate {get; set;}
        [Required]
        public decimal Cost {get; set;}
        public Security Security {get; set;}
        public TrailingStop TrailingStop {get; set;}
        public LowPrice LowPrice {get; set;}
        public HighPrice HighPrice {get; set;}
        public PositionPerformanceMetrics PositionPerformanceMetrics {get; set;}
    }
}