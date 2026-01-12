using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Shared.Enums;

namespace ExpenseManagement.Shared.Models.DtoModels
{
    public sealed class QueryDto
    {
        [Required]
        public EnumQueryTypes QueryTypes { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public long ExpenseCategoryId { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
    }
}

