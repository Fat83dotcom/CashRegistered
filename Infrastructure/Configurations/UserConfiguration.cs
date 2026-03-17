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
        
        builder.Property(user => user.Birthdate).IsRequired().HasColumnType("timestamp");
        
        builder.Property(user => user.Document).IsRequired().HasMaxLength(11);
        
        builder.Property(user => user.Email).IsRequired().HasMaxLength(50);
        
        builder.Property(user => user.HashedPassword).IsRequired().HasMaxLength(255);
        
        builder.Property(user => user.UserName).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(user => user.Email).IsUnique();
        
        builder.HasIndex(user => user.UserName).IsUnique();
        
        builder.Ignore(user => user.RawPassword);
    }
}