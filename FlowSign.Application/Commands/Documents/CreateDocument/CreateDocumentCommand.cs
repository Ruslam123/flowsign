namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Domain.Enums;
public class CreateDocumentCommand
{
    public string Title { get; init; }
    public string? Description { get; init; }
    public SigningType SigningType { get; init; }
    public DataTime? ExpiresAt { get; init; }
    public List<Guid> SignerIds { get; init; }
    public Guid OwnerId { get; init; }
    public string IpAddress { get; init; }
}
