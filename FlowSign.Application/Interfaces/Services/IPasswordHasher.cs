namespace FlowSign.Application.Commands.Auth.RegisterUser

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string hashedPassword, string providedPassword);
}