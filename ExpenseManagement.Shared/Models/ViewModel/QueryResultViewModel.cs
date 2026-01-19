using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManagement.Shared.Models.ViewModel
{
    public class QueryResultViewModel
    {
        public List<DepositViewModel> DepositViewModels { get; set; } = new();
        public List<ExpensesViewModel> ExpensesViewModels { get; set; } = new();
    }
}
