using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

        Task<Stock> GetByIdAsync(Guid id);
        Task<Stock> GetByBloodTypeAsync(EBloodType bloodtype);

        Task AddAsync(Stock contact);

        Task SaveChangesAsync();
    }
}
