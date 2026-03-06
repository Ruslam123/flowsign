using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
namespace FlowSign.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("audit_logs");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.DocumentId).IsRequired(false);
        builder.Property(a => a.UserId).IsRequired();
        builder.Property(a => a.ActionType).HasConversion<string>().IsRequired();
        builder.Property(a => a.Timestamp).IsRequired().HasMaxLength(100);
        builder.Property(a => a.IpAddress).IsRequired();
        builder.Property(a => a.Details).IsRequired(false);
    }
}
