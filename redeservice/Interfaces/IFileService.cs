namespace redeservice.Interfaces
{
    public interface IFileService
    {
        bool SaveFile(string fileName, string path, string content);
    }
}
