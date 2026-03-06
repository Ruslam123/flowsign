using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
namespace FlowSign.Infrastructure.Persistence.Configurations;

public class SignatureRequestConfiguration : IEntityTypeConfiguration<SignatureRequest>
{
    public void Configure(EntityTypeBuilder<SignatureRequest> builder)
    {
        builder.ToTable("signature_requests");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.WorkflowInstanceId).IsRequired();
        builder.Property(s => s.DocumentId).IsRequired();
        builder.Property(s => s.SignerId).IsRequired();
        builder.Property(s => s.Status).HasConversion<string>().IsRequired();
        builder.Property(s => s.Order).IsRequired();
        builder.Property(s => s.SignedAt).IsRequired(false);
        builder.Property(s => s.RejectionReason).IsRequired(false).HasMaxLength(500);
        builder.Property(s => s.DocumentVersionHash).IsRequired(false).HasMaxLength(500);
    }
}
