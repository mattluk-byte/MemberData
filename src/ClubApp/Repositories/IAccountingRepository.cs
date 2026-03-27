using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Models;

namespace ClubApp.Repositories
{
    public interface IAccountingRepository
    {
        Task<List<IncomeRecord>> GetIncomeAsync();
        Task<List<ExpenseRecord>> GetExpenseAsync();
        Task AddIncomeAsync(IncomeRecord r);
        Task AddExpenseAsync(ExpenseRecord r);
        Task UpdateIncomeAsync(IncomeRecord r);
        Task UpdateExpenseAsync(ExpenseRecord r);
        Task DeleteIncomeAsync(IncomeRecord r);
        Task DeleteExpenseAsync(ExpenseRecord r);
    }
}