using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.App.Services;

public class FileUploadService : IFileUploadService
{
    private const int MaxBufferSize = 0x10000;

    public void DeleteFile(string fileName, string webRootPath, string uploadFolder)
    {
        var path = Path.Combine(webRootPath, uploadFolder, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public async Task<string> UploadFileAsync(IBrowserFile inputFile, string webRootPath, string uploadFolder)
    {
        createUploadDir(webRootPath, uploadFolder);
#pragma warning disable CA1062
        var (fileName, imageFilePath) = getOutputFileInfo(inputFile, webRootPath, uploadFolder);
#pragma warning restore CA1062

        await using (var outputFileStream = new FileStream(
                         imageFilePath, FileMode.Create, FileAccess.Write,
                         FileShare.None, MaxBufferSize, useAsync: true))
        {
            await using var inputStream = inputFile.OpenReadStream();
            await inputStream.CopyToAsync(outputFileStream);
        }

        return $"{uploadFolder}/{fileName}";
    }

    private static (string FileName, string FilePath) getOutputFileInfo(
                IBrowserFile inputFile, string webRootPath, string uploadFolder)
    {
        var fileName = Path.GetFileName(inputFile.Name);
        var imageFilePath = Path.Combine(webRootPath, uploadFolder, fileName);
        if (File.Exists(imageFilePath))
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var fileExtension = Path.GetExtension(fileName);
            fileName = $"{fileNameWithoutExtension}-{Guid.NewGuid()}{fileExtension}";
            imageFilePath = Path.Combine(webRootPath, uploadFolder, fileName);
        }
        return (fileName, imageFilePath);
    }

    private static void createUploadDir(string webRootPath, string uploadFolder)
    {
        var folderDirectory = Path.Combine(webRootPath, uploadFolder);
        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }
    }
}
