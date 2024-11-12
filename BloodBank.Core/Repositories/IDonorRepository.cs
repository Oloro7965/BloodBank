using BloodBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllAsync();

        Task<Donor> GetByIdAsync(Guid id);

        Task AddAsync(Donor contact);

        Task SaveChangesAsync();
    }
}
