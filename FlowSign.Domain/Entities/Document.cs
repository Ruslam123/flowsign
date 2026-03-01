using flowsing.Domain.Enums;
using flowsing.Domain.Exceptions;
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
    private readonly List<SignatureRequest> _signatureRequests = new();
    public IReadOnlyList<SignatureRequest> SignatureRequest => _signatureRequests;

    private Document(Guid id, string title, string? description, Guid ownerId, DocumentStatus status, SigningType signingType, DateTime? expiresAt, DateTime createdAt, DateTime updatedAt)
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
    }
    public static Document Create(string title, string? description, Guid ownerId, SigningType signingType, DateTime? expiresAt)
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
            updatedAt: DateTime.UtcNow
            );

    }
    public void Transition(DocumentStatus newStatus)
    {
        if (!CanTransition(newStatus))
        {
            throw new InvalidTransitionException(Status, newStatus);
        }
        Status = newStatus;
    }
    private bool CanTransition(DocumentStatus nextStatus)
    {
        return (Status, nextStatus) switch
        {
            (DocumentStatus.Draft, DocumentStatus.Sent) => true,
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