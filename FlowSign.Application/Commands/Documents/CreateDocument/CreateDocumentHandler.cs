namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Application.Repositories;
public class CreateDocumentHandler
{
    public record CreateDocumentResponse (Guid Id, string Title, string Content, Guid CreatedByUserId, DateTime CreatedAt);
    private readonly IDocumentRepository _documentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public CreateDocumentHandler(IDocumentRepository documentRepository, IUserRepository userRepository, IAuditLogRepository auditLogRepository)
    {
        _documentRepository = documentRepository;
        _userRepository = userRepository;
        _auditLogRepository = auditLogRepository;
    }
    public async Task<Guid> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        // Validate the user exists
        var user = await _userRepository.GetByIdAsync(request.CreatedByUserId);
        if (user == null) {
            throw new Exception("User not found");
        }
        var document = new Domain.Entities.Document
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
            CreatedByUserId = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow
        };
        await _documentRepository.AddAsync(document);
        // Log the creation action in the audit log
        var auditLogEntry = new Domain.Entities.AuditLog
        {
            Id = Guid.NewGuid(),
            UserId = request.CreatedByUserId,
            ActionType = "CreateDocument",
            DocumentId = document.Id,
            Timestamp = DateTime.UtcNow
        };
        await _auditLogRepository.AddAsync(auditLogEntry);
        CreateDocumentResponse response = new CreateDocumentResponse(document.Id, document.Title, document.Content, document.CreatedByUserId, document.CreatedAt);
        return response;
    }
}
