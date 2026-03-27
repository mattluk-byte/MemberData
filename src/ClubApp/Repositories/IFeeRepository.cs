using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Models;

namespace ClubApp.Repositories
{
    public interface IFeeRepository
    {
        Task<List<Fee>> GetAllAsync();
        Task<Fee?> GetByIdAsync(int id);
        Task AddAsync(Fee fee);
        Task UpdateAsync(Fee fee);
        Task DeleteAsync(Fee fee);
    }
}