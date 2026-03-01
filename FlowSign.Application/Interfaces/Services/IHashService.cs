namespace FlowSign.Application.Interfaces.Services;

public interface IHashService
{
    string ComputeSha256(byte[] data);
}
