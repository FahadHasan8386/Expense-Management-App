namespace ExpenseManagement.Api.Models.Entities
{
    public sealed class Deposits : BaseModel
    {
        public long DepositId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime DepositDate { get; set; }
        public string? Remarks { get; set; }
    }
}
