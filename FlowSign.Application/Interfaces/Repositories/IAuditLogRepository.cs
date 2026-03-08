using System.Collections.Generic;
using System.Threading.Tasks;
using FlowSign.Domain.Entities;
namespace FlowSign.Application.Interfaces.Repositories;

public interface IAuditLogRepository
{
    Task AddAsync(AuditLog log);
    Task<List<AuditLog>> GetByDocumentAsync(Guid documentId);
    Task<List<AuditLog>> GetByUserAsync(Guid userId);
}