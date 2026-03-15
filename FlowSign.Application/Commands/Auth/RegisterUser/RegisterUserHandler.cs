namespace FlowSign.Application.Commands.Auth.RegisterUser;
using FlowSign.Application.Interfaces.Repositories;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
using FlowSign.Domain.Exceptions;
public class RegisterUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuditLogRepository _auditLogRepository;
    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IAuditLogRepository auditLogRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _auditLogRepository = auditLogRepository;
    }
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null) { throw new DomainException("Email already in use"); }
        var passwordStrength = var passwordHash = _passwordHasher.Hash(request.Password); 
        var user = new User(Guid.NewGuid(), request.Email, passwordHash, request.Name, request.Role, true, DateTime.UtcNow); 
        await _userRepository.AddAsync(user);
        var auditLog = new AuditLog(Guid.NewGuid(), user.Id, user.Id, ActionType.UserRegistered, DateTime.UtcNow, request.IpAddress, null);
        await _auditLogRepository.AddAsync(auditLog);
        return new RegisterUserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }
}
