using CodeZoneTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeZoneTask.Data.EntitiesConfiguration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).HasPrecision(9, 2);
        }
    }
}
