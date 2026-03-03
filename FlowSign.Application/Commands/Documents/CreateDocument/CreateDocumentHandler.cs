namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Application.Interfaces.Repositories;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
public class CreateDocumentHandler
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public CreateDocumentHandler(IDocumentRepository documentRepository, IUserRepository userRepository, IAuditLogRepository auditLogRepository)
    {
        _documentRepository = documentRepository;
        _userRepository = userRepository;
        _auditLogRepository = auditLogRepository;
    }
    public async Task<CreateDocumentResponse> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        foreach (var signerId in request.SignerIds)
        {
            var user = await _userRepository.GetByIdAsync(signerId);
            if (user == null) { throw new DomainException("Signer not found"); }
        }
        var document = Document.Create(request.Title, request.Description, request.OwnerId, request.SigningType, request.ExpiresAt);
        await _documentRepository.AddAsync(document);
        var auditLog = new AuditLog(Guid.NewGuid(), document.Id, document.OwnerId, ActionType.DocumentCreated, DateTime.UtcNow, request.IpAddress, null);
        await _auditLogRepository.AddAsync(auditLog);
        return new CreateDocumentResponse
        {
            Id = document.Id,
            Title = document.Title,
            Status = document.Status,
            SigningType = document.SigningType,
            CreatedAt = document.CreatedAt,
            ExpiresAt = document.ExpiresAt,
            SignerIds = request.SignerIds
        };
    }
}
