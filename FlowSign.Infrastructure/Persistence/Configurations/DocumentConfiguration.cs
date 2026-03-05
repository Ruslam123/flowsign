namespace FlowSign.Infrastructure.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document> 
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Title).IsRequired().IsRequired().HasMaxLength(200);
        builder.Property(d => d.Description).IsRequired(false);.HasMaxLength(500);
        builder.Property(d => d.OwnerId).IsRequired();
        builder.Property(d => d.Statu).HasConversion<string>().IsRequired();
        builder.Property(d => d.SigningType).HasConversion<string>().IsRequired();
        builder.Property(d => d.ExpiresAt).IsRequired(false);
        builder.Property(d => d.CreatedAt).IsRequired();
        builder.Property(d => d.UpdatedAt).IsRequired();
        builder.HasMany(d => d.Versions)
               .WithOne(v => v.Document)
               .HasForeignKey(v => v.DocumentId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(d => d.SignatureRequest)
               .WithOne(s => s.Document)
               .HasForeignKey(s => s.DocumentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
