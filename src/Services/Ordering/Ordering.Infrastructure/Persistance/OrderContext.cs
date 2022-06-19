using Ordering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Comon;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) 
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "filipe";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "filipe";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
