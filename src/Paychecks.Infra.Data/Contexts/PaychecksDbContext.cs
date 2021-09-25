using Microsoft.EntityFrameworkCore;
using Paychecks.Domain.Entities;
using System.Linq;

namespace Paychecks.Infra.Data.Contexts
{
    public class PaychecksDbContext : DbContext
    {
        public PaychecksDbContext(DbContextOptions<PaychecksDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaychecksDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}