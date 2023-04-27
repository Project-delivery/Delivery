using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Delivery.Models;

namespace Delivery.Data
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.House).IsRequired();
            builder.Property(a => a.Region).IsRequired();
            //builder.HasOne(a => a.User)
            //    .WithMany(u => u.Addresses)
            //    .HasForeignKey(a => a.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
