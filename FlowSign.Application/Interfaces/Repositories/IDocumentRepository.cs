using System.Collections.Generic;
using System.Threading.Tasks;
using flowsing.Domain.Entities;
namespace FlowSign.Application.Interfaces.Repositories;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid id);
    Task<List<Document>> GetByOwnerAsync(Guid ownerId, int page, int pageSize);
    Task AddAsync(Document document);
    Task UpdateAsync(Document document);
    Task<bool> IsOwnerAsync(Guid userId, Guid documentId);
}
