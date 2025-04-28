using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;


        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<Branch>> GetAllAsync() => await Task.FromResult(_context.Branch.ToList());

        public async Task<Branch?> GetByIdAsync(int id) => await _context.Branch.FindAsync(id);
        public async Task<Branch?> GetByNameAsync(string name) => await _context.Branch.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<Branch> AddAsync(Branch Branch)
        {
            var branch = await _context.Branch.AddAsync(Branch);
            await _context.SaveChangesAsync();
            return branch.Entity;
        }

        public async Task UpdateAsync(Branch Branch)
        {
            _context.Branch.Update(Branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Branch = await _context.Branch.FindAsync(id);
            if (Branch != null)
            {
                _context.Branch.Remove(Branch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
