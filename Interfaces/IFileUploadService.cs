using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadAsync(IFormFile file, string folderName);
        Task<bool> DeleteAsync(string relativeFilePath);
    }
}