namespace FlowSign.Application.Interfaces.Services;

public interface IStorageService
{
    string SaveFile(byte[] File, string name);
    string GetFile(byte[] File);
    Task DeletFile(string path);
}
