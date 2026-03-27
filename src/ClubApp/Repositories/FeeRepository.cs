using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Data;
using ClubApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Repositories
{
    public class FeeRepository : IFeeRepository
    {
        private readonly AppDbContext _db;
        public FeeRepository(AppDbContext db) => _db = db;

        public Task<List<Fee>> GetAllAsync() => _db.Fees.AsNoTracking().ToListAsync();
        public Task<Fee?> GetByIdAsync(int id) => _db.Fees.FindAsync(id).AsTask();
        public async Task AddAsync(Fee fee) { _db.Fees.Add(fee); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(Fee fee) { _db.Fees.Update(fee); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(Fee fee) { _db.Fees.Remove(fee); await _db.SaveChangesAsync(); }
    }
}