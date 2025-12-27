using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Shared.Enums
{
    public enum EnumQueryTypes
    {
        [Display(Name = "===Select Query ===")]
        NONE = 0,
        [Display(Name = "Deposit")]
        DepositReport = 1,
        [Display(Name = "Expense")]
        ExpenseReport = 2
    }
}
