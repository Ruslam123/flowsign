namespace FlowSign.Application.Commands.Auth.RegisterUser;
public class RegisterUserCommand : IRequest<RegisterUserResponse>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
