using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infraestructure.Configurations
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Donations).
                WithOne(x => x.Donor).
                HasForeignKey(x => x.DonorId).
                OnDelete(DeleteBehavior.Restrict);
            //builder.Property(x=>x.Email).

        }
    }
}
