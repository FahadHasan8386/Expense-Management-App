namespace ExpenseManagement.Shared.Models.ViewModel
{
    public sealed class HomeViewModel
    {
        public DepositViewModel DepositViewModel { get; set; } = new();
        public ExpensesViewModel ExpensesViewModel { get; set; } = new();
        public List<DepositViewModel> DepositViewModels { get; set; } = [];
        public List<ExpensesViewModel> ExpensesViewModels { get; set; } = [];
    }
}
