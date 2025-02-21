using System.ComponentModel.DataAnnotations;

namespace FinniezProject.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required , Please provide some description")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Amount is required , please provide an Amount")]
        [Range(0.01, double.MaxValue, ErrorMessage ="Amount needs to be more than 0")]
        public double Amount { get; set; }
        [Required]
        public string Category { get; set; } = null!;
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
