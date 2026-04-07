using Domain.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Business.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ActionType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.AffectedTable).IsRequired().HasMaxLength(100);
        builder.Property(x => x.OldDataJson).HasColumnType("jsonb");
        builder.Property(x => x.NewDataJson).HasColumnType("jsonb");
        
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
    }
}
