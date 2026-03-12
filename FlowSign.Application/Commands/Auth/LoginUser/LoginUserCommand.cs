namespace FlowSign.Application.Commands.Auth.RegisterUser;

public class LoginUserCommand : IRequest<LoginUserResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
