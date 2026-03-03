namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Domain.Enums;
public class CreateDocumentCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public SigningType SigningType { get; set; }
    public Data time ExpiresAt { get; set; }
    public List<Guid> SignerIds { get; set; }
    public Guid OwnerId { get; set; }

    public CreateDocumentCommand(string title, string description, SigningType signingType, DateTime expiresAt, List<Guid> signerIds, Guid ownerId)
    {
        Title = title;
        Description = description;
        SigningType = signingType;
        ExpiresAt = expiresAt;
        SignerIds = signerIds;
        OwnerId = ownerId;
    }
}
