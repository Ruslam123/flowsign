namespace FlowSign.Infrastructure.Repositories;
using FlowSign.Application.Interfaces.Repositories;
using FlowSign.Infrastructure.Persistence.Configurations;


public class DocumentRepository : IDocumentRepository
{
	public readonly ApplicationDbContext _context;
    public async Task<Document?> GetByIdAsync(Guid id)
		{
			return await _context.Documents.Include(d => d.Version).Include(d => d.SignatureRequests).FirstOrDefaultAsync(d => d.Id == id);
		}
		public async Task<List<Document>> GetByOwnerAsync(Guid ownerId, int page, int pageSize)
		{
			return await _context.Documents.Where(d => d.OwnerId == ownerId)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}
		public async Task AddAsync(Document document)
		{
			await _context.Documents.AddAsync(document);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateAsync(Document document)
		{
			_context.Documents.Update(document);
			await _context.SaveChangesAsync();
		}
		public async Task<bool> IsOwnerAsync(Guid userId, Guid documentId)
		{
			var document = await _context.Documents.FindAsync(documentId);
			return document != null && document.OwnerId == userId;
    }
}
