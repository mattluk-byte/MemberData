using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Models;

namespace ClubApp.Repositories
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync();
        Task<Activity?> GetByIdAsync(int id);
        Task AddAsync(Activity a);
        Task UpdateAsync(Activity a);
        Task DeleteAsync(Activity a);
    }
}