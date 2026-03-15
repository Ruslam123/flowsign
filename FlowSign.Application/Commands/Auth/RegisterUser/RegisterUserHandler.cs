namespace FlowSign.Application.Commands.Auth.RegisterUser;
using FlowSign.Application.Interfaces.Repositories;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
using FlowSign.Domain.Exceptions;
public class RegisterUserHandler
{
    private readonly IUserRepository _userRepository;
    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null) { throw new DomainException("Email already in use"); }
        var passwordStrength = IPasswordHasher.Hash(request.Password);
        var user = User.Create(request.Name, request.Email, request.Password, request.Role);
        await _userRepository.AddAsync(user);
        var auditLog = new AuditLog(Guid.NewGuid(), user.Id, user.Id, ActionType.UserCreated, DateTime.UtcNow, request.IpAddress, null);
        await _auditLogRepository.AddAsync(auditLog);
        return new RegisterUserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }
}
