using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infraestructure.Persistance.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDBContext _dbcontext;

        public DonorRepository(BloodBankDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Donor donor)
        {
            await _dbcontext.Donors.AddAsync(donor);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAllAsync()
        {
            return await _dbcontext.Donors.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Donors.Where(c => c.IsDeleted.Equals(false) && c.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
