namespace ExpenseManagement.Shared.Models.ViewModel
{
    public sealed class DepositViewModel : BaseModel
    {
        public long DepositId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime DepositDate { get; set; }
        public string? Remarks { get; set; }
    }
}
