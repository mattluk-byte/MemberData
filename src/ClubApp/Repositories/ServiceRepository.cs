using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Data;
using ClubApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _db;
        public ServiceRepository(AppDbContext db) => _db = db;

        public Task<List<ServiceItem>> GetAllAsync() => _db.ServiceItems.AsNoTracking().ToListAsync();
        public Task<ServiceItem?> GetByIdAsync(int id) => _db.ServiceItems.FindAsync(id).AsTask();
        public async Task AddAsync(ServiceItem item) { _db.ServiceItems.Add(item); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(ServiceItem item) { _db.ServiceItems.Update(item); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(ServiceItem item) { _db.ServiceItems.Remove(item); await _db.SaveChangesAsync(); }
    }
}