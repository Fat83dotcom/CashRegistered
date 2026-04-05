using Domain.Financial.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Financial.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.Property(e => e.ExpenseDescription).IsRequired().HasMaxLength(100);
        
        builder.Property(e => e.ExpenseValue).IsRequired().HasColumnType("decimal(18,2)");
        
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.CashFlow)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CashFlowId);
    }
}