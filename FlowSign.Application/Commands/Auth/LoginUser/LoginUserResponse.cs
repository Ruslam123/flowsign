namespace FlowSign.Application.Commands.Auth.LoginUser;
using 
public class LoginUserResponse
{
    public string UserName { get; set; }
    public string Token { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
