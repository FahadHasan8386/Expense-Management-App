using ExpenseManagement.Shared.Models;

namespace ExpenseManagement.Api.Models.Entities
{
    public sealed class ExpenseCategories : BaseModel
    {
        public long ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; } = string.Empty;
        public string? Remarks { get; set; }
        
    }
}
