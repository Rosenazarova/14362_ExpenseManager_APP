using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _14362_ExpenseManager.DAL.Models
{
    public class Expense
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Min amount value is 0.1!")]
        public double Amount { get; set; }
        public int? ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public ExpenseType? ExpenseType { get; set; }

    }
}
