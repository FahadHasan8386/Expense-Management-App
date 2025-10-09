using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Api.Models.Dtos
{
    public class ExpenseCategories
    {
        public long ExpenseCategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string ExpenseCategoryName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Remarks is required.")]
        public string? Remarks { get; set; }
    }
}
