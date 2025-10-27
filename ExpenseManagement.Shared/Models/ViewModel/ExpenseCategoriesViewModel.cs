namespace ExpenseManagement.Shared.Models.ViewModel
{
    public sealed class ExpenseCategoriesViewModel : BaseModel
    {
        public long ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; } = string.Empty;
        public string? Remarks { get; set; }
    }
}
