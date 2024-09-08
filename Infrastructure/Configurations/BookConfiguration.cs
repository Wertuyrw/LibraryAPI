using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(isbn => isbn.ISBN)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(title => title.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(genre => genre.Genre)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(description => description.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(borrowTime => borrowTime.CheckoutDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(returnDate => returnDate.ReturnDate)
                .HasDefaultValue(DateTime.Now.AddDays(7));
        }
    }
}
