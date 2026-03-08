namespace FlowSign.Infrastructure.Repositories;
using FlowSign.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using FlowSign.Domain.Entities;
using FlowSign.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
	private readonly FlowSignDbContext _context;
	public UserRepository(FlowSignDbContext context)
	{
		_context = context;
	}
	public async Task<User?> GetByIdAsync(Guid id)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
	}
	public async Task<User?> GetByEmailAsync(string email)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
	}
	public async Task AddAsync(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
	}
	public async Task<bool> ExistsWithEmailAsync(string email)
	{
		return await _context.Users.AnyAsync(u => u.Email == email);
	}
}
