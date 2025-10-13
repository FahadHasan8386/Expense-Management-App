using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Api.Models.Dtos
{
    public class DepositDto 
    {
        public long DepositId { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Deposit amount is required.")]
        public decimal DepositAmount { get; set; }

        [Required]
        public DateTime? DepositDate { get; set; }

        public string? Remarks { get; set; }
    }
}
