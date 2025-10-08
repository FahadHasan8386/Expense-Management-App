namespace ExpenseManagement.Api.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; } = "Fahad";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool InActive { get; set; } = false;
        public string? ModifiedBy { get; set; } = "Fahad";
        public DateTime? ModifiedAt { get; set; } = DateTime.Now;
    }
}
