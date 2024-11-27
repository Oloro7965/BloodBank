using Azure.Core;
using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infraestructure.Persistance.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly BloodBankDBContext _dbcontext;

        public StockRepository(BloodBankDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Stock stock)
        {
            await _dbcontext.Stocks.AddAsync(stock);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Stock>> GetAllAsync()
        { 
            return await _dbcontext.Stocks.ToListAsync();
        }

        public async Task<Stock> GetByBloodTypeAsync(EBloodType bloodtype)
        {
            return await _dbcontext.Stocks.Where(c => c.BloodType==bloodtype)
                .SingleOrDefaultAsync();
        }

        public async Task<Stock> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Stocks.Where(c =>c.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
