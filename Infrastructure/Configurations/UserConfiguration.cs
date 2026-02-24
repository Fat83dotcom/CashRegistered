using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.OwnsOne(user => user.Name, name =>
        {
            name.Property(u => u.FirstName).IsRequired().HasMaxLength(20);
            name.Property(u => u.LastName).IsRequired(false).HasMaxLength(20);
        });
        
        builder.Property(user => user.Birthdate).IsRequired().HasColumnType("timestamp with time zone");
        
        builder.Property(user => user.Document).IsRequired().HasMaxLength(11);

        builder.Ignore(user => user.IsValid);
    }
}