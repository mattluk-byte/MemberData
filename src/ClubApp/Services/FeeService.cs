using System.Collections.Generic;
using System.Threading.Tasks;
using ClubApp.Models;
using ClubApp.Repositories;

namespace ClubApp.Services
{
    public interface IFeeService
    {
        Task<List<Fee>> GetAllAsync();
        Task<Fee?> GetByIdAsync(int id);
        Task AddAsync(Fee fee);
        Task UpdateAsync(Fee fee);
        Task DeleteAsync(Fee fee);
    }

    public class FeeService : IFeeService
    {
        private readonly IFeeRepository _repo;
        public FeeService(IFeeRepository repo) => _repo = repo;

        public Task<List<Fee>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Fee?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Fee fee) => _repo.AddAsync(fee);
        public Task UpdateAsync(Fee fee) => _repo.UpdateAsync(fee);
        public Task DeleteAsync(Fee fee) => _repo.DeleteAsync(fee);
    }
}