
using ExpenseManagement.Shared.Enums;

namespace ExpenseManagement.Shared.Models.ViewModel
{
    public sealed class ExpensesViewModel : BaseModel
    {
        public long ExpenseId { get; set; }
        public long ExpenseCategoryId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public EnumPaymentType PaymentMethod { get; set; } = EnumPaymentType.NONE;
        public string? Remarks { get; set; }
    }
}
