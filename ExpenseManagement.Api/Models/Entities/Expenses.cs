namespace ExpenseManagement.Api.Models.Entities
{
    public sealed class Expenses : BaseModel
    {
        public long ExpenseId { get; set; }
        public long ExpenseCategoryId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? Remarks { get; set; }
    }
}
