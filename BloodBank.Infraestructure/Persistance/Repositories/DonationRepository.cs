using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infraestructure.Persistance.Repositories
{
    public class DonationRepository : IDonationRepository
    {

        private readonly BloodBankDBContext _dbcontext;

        public DonationRepository(BloodBankDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Donation donation)
        {
            await _dbcontext.Donations.AddAsync(donation);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Donation>> GetAllAsync()
        {
            return await _dbcontext.Donations.ToListAsync();
        }

        public async Task<Donation> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Donations
                .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
