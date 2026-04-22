using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AM.ApplicationCore.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    
        public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
        {
            public void Configure(EntityTypeBuilder<Plane> builder)
            {
                builder.HasMany(p => p.Flights)
                       .WithOne(f => f.Plane)
                       .HasForeignKey(f => f.PlaneId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }