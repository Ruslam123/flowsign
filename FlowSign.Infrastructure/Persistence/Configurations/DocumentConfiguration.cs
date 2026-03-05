using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;

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
        builder.HasMany(d => d.Versions)
               .WithOne()
               .HasForeignKey(v => v.DocumentId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(d => d.SignatureRequest)
               .WithOne()
               .HasForeignKey(s => s.DocumentId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasField("_versions").UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.HasField("_signatureRequests").UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
