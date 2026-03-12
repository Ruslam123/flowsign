namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Domain.Enums;
public class CreateDocumentResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public DocumentStatus Status { get; init; }
    public SigningType SigningType { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public List<Guid> SignerIds { get; init; }
}
