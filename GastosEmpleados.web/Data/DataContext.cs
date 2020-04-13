using GastosEmpleado.Web.Data.Entities;
using GastosEmpleados.web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GastosEmpleados.web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EmployeesEntity> Employees { get; set; }
        public DbSet<CitiesEntity> Cities { get; set; }
        public DbSet<CountriesEntity> Countries { get; set; }
        public DbSet<TripsEntity> Trips { get; set; }
        public DbSet<TripDetailsEntity> TripDetails { get; set; }
        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmployeesEntity>()
                .HasIndex(t => t.Document)
                .IsUnique();
        }


    }
}
