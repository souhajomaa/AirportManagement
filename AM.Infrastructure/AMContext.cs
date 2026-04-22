using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetColumnType("datetime");
                    }
                }
            }
            modelBuilder.Entity<Passenger>()
           .Property(p => p.TelNumber)
           .HasColumnName("NumTel");
            //chp3 s3 etape 13 fullname
            modelBuilder.Entity<Passenger>()
        .OwnsOne(p => p.FullName, fn =>
        {
            //contrainte  
            fn.Property(f => f.FirstName).HasColumnName("FullNameFirst");
            fn.Property(f => f.LastName).HasColumnName("FullNameLast");
        });
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

        }
    }
}