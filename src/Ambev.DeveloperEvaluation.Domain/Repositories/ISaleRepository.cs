using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<List<Sales>> GetAllAsync();
        Task<Sales> GetByIdAsync(string id);
        Task CreateAsync(Sales sale);
        Task UpdateAsync(Sales sale);
        Task DeleteAsync(string id);
        Task<int> GetNextSequenceValue(string counterName);
    }
}
