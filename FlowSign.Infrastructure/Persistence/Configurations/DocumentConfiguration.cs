using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
namespace FlowSign.Infrastructure.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("documents");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Title).IsRequired().HasMaxLength(200);
        builder.Property(d => d.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(d => d.OwnerId).IsRequired();
        builder.Property(d => d.Status).HasConversion<string>().IsRequired();
        builder.Property(d => d.SigningType).HasConversion<string>().IsRequired();
        builder.Property(d => d.ExpiresAt).IsRequired(false);
        builder.Property(d => d.CreatedAt).IsRequired();
        builder.Property(d => d.UpdatedAt).IsRequired();
        builder.Navigation(d => d.Versions).HasField("_versions");
        builder.Navigation(d => d.SignatureRequests).HasField("_signatureRequests");
    }
}
