using System.Security.Cryptography;
namespace FlowSign.Application.Interfaces.Services;

public interface IhashService
{
    string GetSha256Hash(byte[] data)
    {
        byte[] hash = SHA256.HashData(data);
        return Convert.ToHexString(hash).ToLower(); // .ToLower() если нужен нижний регистр
    }
}
