using ExpenseManagement.Shared.Enums;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public DateTime FromDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ToDate { get; set; } = DateTime.Now;
    }
}

