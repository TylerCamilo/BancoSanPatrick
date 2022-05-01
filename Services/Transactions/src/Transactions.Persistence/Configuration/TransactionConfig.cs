using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.Domain.Entities;

namespace Transactions.Persistence.Configuration
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.OriginCard)
                .IsRequired()
                .HasMaxLength(10); 

            builder.Property(p => p.DestinationCard)
                .IsRequired()
                .HasMaxLength(10); 

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.ReferenceNumber)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
