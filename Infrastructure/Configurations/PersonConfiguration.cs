using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        
        builder.OwnsOne(person => person.Name, name =>
        {
            name.Property(u => u.FirstName).IsRequired().HasMaxLength(20);
            name.Property(u => u.LastName).IsRequired(false).HasMaxLength(20);
        });

        builder.Property(person => person.Gender)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(person => person.Birthdate).IsRequired().HasColumnType("timestamp");
        
        builder.Property(person => person.Document).IsRequired().HasMaxLength(11);
        
        builder.Property(person => person.Email).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(person => person.Email).IsUnique();
        

    }
}