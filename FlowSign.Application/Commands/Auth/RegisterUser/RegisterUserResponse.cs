namespace FlowSign.Application.Commands.Auth.RegisterUser;

public class RegisterUserResponse
{
    public Guid Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Email { get; init; }
    public string UserNameHash { get; init; }
    public string EmailHash { get; init; }
    public string PasswordHash { get; init; }
}
