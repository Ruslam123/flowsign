namespace FlowSign.Application.Commands.Auth.RegisterUser;
using FlowSign.Domain.Enums;
public class RegisterUserCommand
{
    public string FullName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public UserRole Role { get; init; }
    public string IpAddress { get; init; }
}
