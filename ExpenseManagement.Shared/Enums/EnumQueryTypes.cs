using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Enums
{
    public enum EnumQueryTypes
    {
        [Display(Name = "===Select Query Types===")]
        NONE = 0,
        [Display(Name = "Deposit")]
        DepositReport = 1,
        [Display(Name = "Expense")]
        ExpenseReport = 2
    }
}
