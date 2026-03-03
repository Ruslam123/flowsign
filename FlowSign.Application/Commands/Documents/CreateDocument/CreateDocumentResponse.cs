namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Domain.Enums;
public class CreateDocumentResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public DocumentStatus Status { get; init; }
    public SigningType SigningType { get; init; }
    public DataTime CreatedAt { get; init; }
    public DataTime ExpiresAt { get; init; }
    public List<Guid> SignerIds { get; init; }
}
