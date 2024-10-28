using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infraestructure.Persistance
{
   public class BloodBankDBContext:DbContext
    {
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public BloodBankDBContext(DbContextOptions<BloodBankDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
