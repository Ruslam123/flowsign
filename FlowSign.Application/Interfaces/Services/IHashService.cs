namespace FlowSign.Application.Interfaces.Services;

public interface IhashService
{
    string ComputeSha256(byte[] data)
}
