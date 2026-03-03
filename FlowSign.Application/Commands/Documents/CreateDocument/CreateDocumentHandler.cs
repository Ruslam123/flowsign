namespace FlowSign.Application.Commands.Documents.CreateDocument;
using FlowSign.Application.Repositories;
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
    public async CreateDocumentResponse Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        Documents document;
        foreach (signerId in request.SignerIds)
        {
            user = await _userRepository.GetByIdAsync(signerId);
            if (user == null) { throw DomainException("Signer not found"); }
        }
        document.Create(request.Title, request.Description, request.OwnerId, request.SigningType, request.ExpiresAt);
        await _documentRepository.AddAsync(document);
        auditLog = new AuditLog(Guid.NewGuid(), document.Id, document.OwnerId, ActionType.DocumentCreated, DateTime.UtcNow, null, null);
        await _auditLogRepository.AddAsync(auditLog)
        return new CreateDocumentResponse(document.Id);
    }
}
