namespace FlowSign.Application.Interfaces.Services;

public interface IStorageService
{
    byte[] SaveFile(string key);
    byte[] GetFile(string key);
    byte[] DeletFile(string key);
}
