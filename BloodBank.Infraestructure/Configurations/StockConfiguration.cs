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
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.BloodType).HasConversion<string>()
                .IsRequired();
            builder.Property(b => b.RhFactor).HasConversion<string>()
                .IsRequired();
            builder.Property(b => b.QuantityML).IsRequired();
        }
    }
}
