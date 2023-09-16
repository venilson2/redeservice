using redeservice.Models;

namespace redeservice.Interfaces
{
    public interface IFileService
    {
        bool SaveFile(string fileName, string path, string content);
        List<ClsTeste> getDataJson(string fileName, string path);
    }
}
