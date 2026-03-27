using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Data;
using ClubApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _db;
        public ActivityRepository(AppDbContext db) => _db = db;

        public Task<List<Activity>> GetAllAsync() => _db.Activities.AsNoTracking().Include(a => a.Organizer).ToListAsync();
        public Task<Activity?> GetByIdAsync(int id) => _db.Activities.FindAsync(id).AsTask();
        public async Task AddAsync(Activity a) { _db.Activities.Add(a); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(Activity a) { _db.Activities.Update(a); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(Activity a) { _db.Activities.Remove(a); await _db.SaveChangesAsync(); }
    }
}