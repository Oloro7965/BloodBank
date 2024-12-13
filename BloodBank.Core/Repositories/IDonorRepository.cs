using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllAsync(EBloodType? bloodtype);

        Task<Donor> GetByIdAsync(Guid id);

        Task AddAsync(Donor contact);

        //Task<bool> IsEmailRegisteredAsync(string email);
        Task<Donor> SearchByEmailAsync(string email);
        Task SaveChangesAsync();
    }
}
