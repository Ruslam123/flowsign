using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
namespace FlowSign.Infrastructure.Persistence.Configurations;

public class WorkflowInstanceConfiguration : IEntityTypeConfiguration<WorkflowInstance>
{
    public void Configure(EntityTypeBuilder<WorkflowInstance> builder)
    {
        builder.ToTable("workflow_instances");
        builder.HasKey(w => w.Id);
        builder.Property(w => w.DocumentId).IsRequired();
        builder.Property(w => w.SigningType).HasConversion<string>().IsRequired();
        builder.Property(w => w.Status).HasConversion<string>().IsRequired();
        builder.Property(w => w.StartedAt).IsRequired();
        builder.Property(w => w.CompletedAt).IsRequired(false);
        builder.Property(w => w.InitiatedBy).IsRequired();
    }
}
