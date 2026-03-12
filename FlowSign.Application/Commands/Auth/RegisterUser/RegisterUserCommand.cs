namespace FlowSign.Application.Commands.Auth.RegisterUser;
public class RegisterUserCommand
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string IpAddress { get; set; }
}
