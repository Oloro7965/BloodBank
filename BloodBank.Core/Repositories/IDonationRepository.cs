﻿using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAllAsync();

        Task<Donation> GetByIdAsync(Guid id);

        Task AddAsync(Donation contact);

        Task SaveChangesAsync();
        Task<List<Donation>> GetByDonorId(Guid id);
    }
}
