namespace FlowSign.Application.Commands.Auth.LoginUser;
using FlowSign.Application.Interfaces.Repositories;
using FlowSign.Application.Interfaces.Services;
using FlowSign.Domain.Entities;
using FlowSign.Domain.Enums;
using FlowSign.Domain.Exceptions;
public class LoginUserHandler
{
    private readonly IAuditLogRepository _auditLogRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    public LoginUserHandler(IAuditLogRepository auditLogRepository, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
    {
        _auditLogRepository = auditLogRepository;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }
    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            throw new DomainException("Invalid email or password");
        }
        var auditLogSuccess = new AuditLog(Guid.NewGuid(), user.Id, user.Id, ActionType.UserLoggedIn, DateTime.UtcNow, request.IpAddress, null);
        await _auditLogRepository.AddAsync(auditLogSuccess);
        return new LoginUserResponse
        {
            UserName = user.FullName,
            Token = _jwtService.GenerateToken(user),
            UserId = user.Id,
            Email = user.Email,
            Role = user.Role
        };
    }
}
