using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Shared.Models.DtoModels.DepositDto
{
    public class DepositDto : BaseModel
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
