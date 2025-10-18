using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Api.Models.Dtos.DepositDto
{
    public class UpdateDepositDto : BaseModel
    {
        [Required]
        public long DepositId { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Deposit amount is required.")]
        public decimal DepositAmount { get; set; }

        // DepositDate is optional during update
        public DateTime? DepositDate { get; set; }

        public string? Remarks { get; set; }
    }
}
