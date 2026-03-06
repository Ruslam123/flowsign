using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
namespace FlowSign.Infrastructure.Persistence.Configurations;

public class DocumentVersionConfiguration : IEntityTypeConfiguration<DocumentVersion>
{
    public void Configure(EntityTypeBuilder<DocumentVersion> builder)
    {
        builder.ToTable("document_versions");
        builder.HasKey(dv => dv.Id);
        builder.Property(dv => dv.DocumentId).IsRequired();
        builder.Property(dv => dv.FilePath).IsRequired().HasMaxLength(500);
        builder.Property(dv => dv.OriginalFileName).IsRequired().HasMaxLength(500);
        builder.Property(dv => dv.FileSizeBytes).IsRequired();
        builder.Property(dv => dv.SHA256Hash).IsRequired().HasMaxLength(64);
        builder.Property(dv => dv.VersionNumber).IsRequired();
        builder.Property(dv => dv.UpdatedAt).IsRequired();
    }
}
