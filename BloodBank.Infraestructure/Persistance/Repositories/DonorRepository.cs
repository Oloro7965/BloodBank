using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
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

        public async Task<List<Donor>> GetAllAsync(EBloodType? bloodtype)
        {
            if (bloodtype is null)
            {
                return await _dbcontext.Donors.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
            }
            else 
            {
                return await _dbcontext.Donors.Where(u => u.IsDeleted.Equals(false) 
                && u.BloodType==bloodtype).ToListAsync();
            }
        }        

        public async Task<Donor> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Donors.Where(c => c.IsDeleted.Equals(false) && c.Id == id)
                .SingleOrDefaultAsync();
        }
        
        //public async Task<bool> IsEmailRegisteredAsync(string email)
        //{
            //if (_dbcontext.Donors.Where(d=>d.Email == email).SingleOrDefaultAsync()==false);
        //    await _dbcontext.SaveChangesAsync();
        //}

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Donor> SearchByEmailAsync(string email)
        {
            return await _dbcontext.Donors.Where(c => c.IsDeleted.Equals(false) && c.Email==email)
                .SingleOrDefaultAsync();
        }
    }
}
