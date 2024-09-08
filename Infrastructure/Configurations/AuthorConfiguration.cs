using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(firstName => firstName.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(lastName => lastName.LastName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
