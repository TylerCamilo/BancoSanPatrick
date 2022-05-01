using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Transactions.Application.Interfaces;
using Transactions.Domain.Common;
using Transactions.Domain.Entities;

namespace Transactions.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTime;
        }

        //public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = _dateTimeService.NowUTC;
                        break;
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid().ToString();
                        entry.Entity.CreatedAt = _dateTimeService.NowUTC;
                        break;
                    default:
                        break;
                }
            }
            return  base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
