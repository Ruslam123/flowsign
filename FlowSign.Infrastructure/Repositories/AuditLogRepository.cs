namespace FlowSign.Infrastructure.Repositories;
using FlowSign.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using FlowSign.Domain.Entities;
using FlowSign.Infrastructure.Persistence;

public class AuditLogRepository : IAuditLogRepository
{
	private readonly FlowSignDbContext _context;
	public AuditLogRepository(FlowSignDbContext context)
	{
		_context = context;
	}
	public async Task<List<AuditLog>> GetByDocumentIdAsync(Guid documentId)
	{
		return await _context.AuditLogs.Where(a => a.DocumentId == documentId).ToListAsync();
    }
	public async Task AddAsync(AuditLog auditLog)
	{
		await _context.AuditLogs.AddAsync(auditLog);
		await _context.SaveChangesAsync();
    }
	public async Task<List<AuditLog>> GetByUserIdAsync(Guid userId)
	{
		return await _context.AuditLogs.Where(a => a.UserId == userId).ToListAsync();
    }

}
