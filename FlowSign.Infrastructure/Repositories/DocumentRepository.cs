namespace FlowSign.Infrastructure.Repositories;
using FlowSign.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using FlowSign.Domain.Entities;
using FlowSign.Infrastructure.Persistence;

public class DocumentRepository : IDocumentRepository
{
    private readonly FlowSignDbContext _context;
	public DocumentRepository(FlowSignDbContext context)
	{
		_context = context;
	}
	public async Task<Document?> GetByIdAsync(Guid id)
	{
		return await _context.Documents.Include(d => d.Versions).Include(d => d.SignatureRequests).FirstOrDefaultAsync(d => d.Id == id);
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
		return await _context.Documents.AnyAsync(d => d.Id == documentId && d.OwnerId == userId);
	}
}
