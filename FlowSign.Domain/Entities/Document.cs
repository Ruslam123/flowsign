using flowsing.Domain.Enums;
namespace flowsing.Domain.Entities;
public class Document
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Guid OwnerId { get; private set; }
    public DocumentStatus Status { get; private set; }
    public SigningType SigningType { get; private set; }
    public DateTime? ExpiresAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    private readonly List<DocumentVersion> _versions = new();
    public IReadOnlyList<DocumentVersion> Versions => _versions;
    public IReadOnlyList<SignatureRequest> SignatureRequest { get; private set; }

    private Document(Guid id, string title, string? description, Guid ownerId, DocumentStatus status, SigningType signingType, DateTime? expiresAt, DateTime createdAt, DateTime updatedAt, IReadOnlyList<DocumentVersion> documentVersion, IReadOnlyList<SignatureRequest> signatureRequest)
    {
        Id = id;
        Title = title;
        Description = description;
        OwnerId = ownerId;
        Status = status;
        SigningType = signingType;
        ExpiresAt = expiresAt;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DocumentVersion = documentVersion;
        SignatureRequest = signatureRequest;
    }
    private static Document Create(string title, string? description, Guid ownerId, SigningType signingType, DateTime? expiresAt)
    {
        return new Document(
            id: Guid.NewGuid(),
            title: title,
            description: description,
            ownerId: ownerId,
            status: DocumentStatus.Draft,
            signingType: signingType,
            expiresAt: expiresAt,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow,
            documentVersion: new List<DocumentVersion>(),
            signatureRequest: new List<SignatureRequest>()
            );

    }
    private void Transition(DocumentStatus newStatus)
    {
        if (!CanTransition(nextStatus))
        {
            throw new InvalidOperationException($"Impossible transition from {Status} to {nextStatus}");
        }
        Status = nextStatus;
    }
    private bool CanTransition(DocumentStatus nextStatus)
    {
        return (Status, nextStatus) switch
        {
            (DocumentStatus.Draft, DocumentStatus.) => true,
            (DocumentStatus.Draft,DocumentStatus.Archived) => true,
            (DocumentStatus.Sent, DocumentStatus.Viewed) => true,
            (DocumentStatus.Sent, DocumentStatus.Rejected) => true,
            (DocumentStatus.Viewed, DocumentStatus.Signed) => true,
            (DocumentStatus.Viewed, DocumentStatus.Rejected) => true,
            (DocumentStatus.Signed, DocumentStatus.Archived) => true,
            (DocumentStatus.Rejected, DocumentStatus.Draft) => true,
            (DocumentStatus.Rejected, DocumentStatus.Archived) => true,
            _ => false
        };
    }
}
