using System;
namespace flowsing.Domain.Entities;

public class DocumentVersion
{
    public Guid Id { get; private set; }
    public Guid DocumentId { get; private set; }
    public string FilePath { get; private set; }
    public string OriginalFileName { get; private set; }
    public long FileSizeBytes { get; private set; }
    public string SHA256Hash { get; private set; }
    public int VersionNumber { get; private set; }
    public DateTime UploadedAt { get; private set; }

}
