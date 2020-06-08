using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Trowoo.Models
{
    public class PositionPerformanceMetrics
    {
        public int Id {get; set;}
        [Required]
        [ForeignKey("PositionId")]
        public int PositionId {get; set;}
        public decimal OneDayChange {get; set;}
        public decimal SevenDayChange {get; set;}
        public decimal OneMonthChange {get; set;}
        public decimal ThreeMonthChange {get; set;}
        public decimal SixMonthChange {get; set;}
        public decimal NineMonthChange {get; set;}
        public decimal OneYearChange {get; set;}
        public decimal TwoYearChange {get; set;}
        public decimal ThreeYearChange {get; set;}
        public decimal FiveYearChange {get; set;}
        public decimal TenYearChange {get; set;}
        public decimal MonthToDateChange {get; set;}
        public decimal QuarterToDateChange {get; set;}
        public decimal YearToDateChange {get; set;}
        public decimal InceptionToDateChange {get; set;}
    }
}