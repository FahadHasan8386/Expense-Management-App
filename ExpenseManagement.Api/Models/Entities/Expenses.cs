using ExpenseManagement.Shared.Enums;
using ExpenseManagement.Shared.Models;

namespace ExpenseManagement.Api.Models.Entities
{
    public sealed class Expenses : BaseModel
    {
        public long ExpenseId { get; set; }
        public long ExpenseCategoryId { get; set; }
        public ExpenseCategories ExpenseCategories { get; set; } = new();
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public EnumPaymentType PaymentMethod { get; set; }
        public string? Remarks { get; set; }
    }
}
