namespace FlowSign.Application.Commands.Auth.RegisterUser;
public class RegisterUserResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
    public string Role { get; init; }
    public DateTime CreatedAt { get; init; }
}
