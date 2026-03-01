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

    public DocumentVersion(Guid id, Guid documentId, string filePath, string originalFileName, long fileSizeBytes, string sha256Hash, int versionNumber, DateTime uploadedAt)
    {
        Id = id;
        DocumentId = documentId;
        FilePath = filePath;
        OriginalFileName = originalFileName;
        FileSizeBytes = fileSizeBytes;
        SHA256Hash = sha256Hash;
        VersionNumber = versionNumber;
        UploadedAt = uploadedAt;
    }
}
