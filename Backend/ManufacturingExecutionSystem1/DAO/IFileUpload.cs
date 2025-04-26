namespace ManufacturingExecutionSystem1.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFileAsync(IFormFile file, string location,string name, string type);
        Task<string> DeleteFileAsync(string location, string directory_name, string type);
        Task<string> renameDirectory(string location, string old_name, string new_name);
        Task<int> CkeckFileExist(IFormFile file, string location, string name, string type);
        void deleteDirectory(string location, string directory_name);
    }
}
