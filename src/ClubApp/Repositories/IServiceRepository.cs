using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Models;

namespace ClubApp.Repositories
{
    public interface IServiceRepository
    {
        Task<List<ServiceItem>> GetAllAsync();
        Task<ServiceItem?> GetByIdAsync(int id);
        Task AddAsync(ServiceItem item);
        Task UpdateAsync(ServiceItem item);
        Task DeleteAsync(ServiceItem item);
    }
}