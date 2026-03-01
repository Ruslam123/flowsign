namespace FlowSign.Application.Interfaces.Services;

public interface IStorageService
{
    Task<string> SaveFileAsync(byte[] File, string name);
    Task<byte[]> GetFileAsync(string path);
    Task DeleteFileAsync(string path);
}
