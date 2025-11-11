using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Enums
{
    public enum EnumPaymentType
    {
        [Display(Name = "===Select Payment===")]
        NONE = 0,
        [Display(Name = "Cash")]
        CASH = 1,
        [Display(Name = "Bkash")]
        BKASH = 2,
        [Display(Name = "Rocket")]
        ROCKET = 3,
        [Display(Name = "Nagad")]
        NAGAD = 4,
        [Display(Name = "Debit Card")]
        DEBIT_CARD = 4,
        [Display(Name = "Credit Card")]
        CREDIT_CARD = 5,
        [Display(Name = "Bank Account")]
        BANK_ACCOUNT = 6
    }
}
