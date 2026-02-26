using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class CashFlowConfiguration : IEntityTypeConfiguration<CashFlow>
{
    public void Configure(EntityTypeBuilder<CashFlow> builder)
    {
        builder.ToTable("CashFlows");
        
        builder.Property(cashFlow => cashFlow.CurrentBalance).IsRequired(false).HasColumnType("decimal(18,2)");

        builder.HasKey(cashFlow => cashFlow.Id);

        builder.HasOne(c => c.User)
            .WithOne(u => u.CashFlow)
            .HasForeignKey<CashFlow>(c => c.UserId)
            .IsRequired();
    }
}