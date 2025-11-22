using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.App.Services;
internal interface IFileUploadService
{
    public void DeleteFile(string fileName, string webRootPath, string uploadFolder);
    public Task<string> UploadFileAsync(IBrowserFile inputFile, string webRootPath, string uploadFolder);
}
