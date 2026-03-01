namespace FlowSign.Application.Interfaces.Services;
using FlowSign.Domain.Entities;

public interface IJwtService
{
    string GenerateToken(User user);
}
