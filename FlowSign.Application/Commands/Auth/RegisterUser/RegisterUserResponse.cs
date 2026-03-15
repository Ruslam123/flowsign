namespace FlowSign.Application.Commands.Auth.RegisterUser;
using FlowSign.Domain.Enums;

public class RegisterUserResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
    public UserRole Role { get; init; }
    public DateTime CreatedAt { get; init; }
}
