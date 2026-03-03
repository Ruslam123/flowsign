namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Domain.Enums;
public class CreateDocumentResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DocumentStatus Status { get; set; }
    public SigningType SigningType { get; set; }
    public Data time CreatedAt { get; set; }
    public Data time ExpiresAt { get; set; }
    public List<Guid> SignerIds { get; set; }

    public CreateDocumentResponse(Guid id, string title, DocumentStatus status, SigningType signingType, DateTime createdAt, DateTime expiresAt, List<Guid> signerIds)
    {
        Id = id;
        Title = title;
        Status = status.Draft;
        SigningType = signingType;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
        SignerIds = signerIds;
    }

}
