using System.ComponentModel.DataAnnotations;

namespace _14362_ExpenseManager.DAL.Models
{
    public class ExpenseType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of expense type name is required")]
        public string Name { get; set; }
    }
}
