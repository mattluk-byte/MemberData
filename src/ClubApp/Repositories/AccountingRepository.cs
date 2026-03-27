using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Data;
using ClubApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Repositories
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly AppDbContext _db;
        public AccountingRepository(AppDbContext db) => _db = db;

        public Task<List<IncomeRecord>> GetIncomeAsync() => _db.IncomeRecords.AsNoTracking().Include(i => i.IncomeItem).ToListAsync();
        public Task<List<ExpenseRecord>> GetExpenseAsync() => _db.ExpenseRecords.AsNoTracking().Include(e => e.ExpenseItem).ToListAsync();
        public async Task AddIncomeAsync(IncomeRecord r) { _db.IncomeRecords.Add(r); await _db.SaveChangesAsync(); }
        public async Task AddExpenseAsync(ExpenseRecord r) { _db.ExpenseRecords.Add(r); await _db.SaveChangesAsync(); }
        public async Task UpdateIncomeAsync(IncomeRecord r) { _db.IncomeRecords.Update(r); await _db.SaveChangesAsync(); }
        public async Task UpdateExpenseAsync(ExpenseRecord r) { _db.ExpenseRecords.Update(r); await _db.SaveChangesAsync(); }
        public async Task DeleteIncomeAsync(IncomeRecord r) { _db.IncomeRecords.Remove(r); await _db.SaveChangesAsync(); }
        public async Task DeleteExpenseAsync(ExpenseRecord r) { _db.ExpenseRecords.Remove(r); await _db.SaveChangesAsync(); }
    }
}