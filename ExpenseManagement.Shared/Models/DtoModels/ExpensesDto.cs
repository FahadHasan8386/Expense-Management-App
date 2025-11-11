using System.ComponentModel.DataAnnotations;
using ExpenseManagement.Shared.Enums;
using ExpenseManagement.Shared.Models;

namespace ExpenseManagement.Shared.Models.DtoModels
{
    public class ExpensesDto : BaseModel
    {
        public long ExpenseId { get; set; }

        [Required(ErrorMessage = "Expense Category is Required")]
        public long ExpenseCategoryId { get; set; }

        [Required(ErrorMessage = "Expense Amount is Required")]  
        [Range(1, Double.MaxValue, ErrorMessage = "Expense amount id must be grater than 0 .")]
        public decimal ExpenseAmount { get; set; }

        [Required]
        public DateTime? ExpenseDate { get; set; }

        [Required(ErrorMessage = "Payment Method is Required")]
        public EnumPaymentType PaymentMethod { get; set; } = EnumPaymentType.NONE;
        public string? Remarks { get; set; }
    }
}
  