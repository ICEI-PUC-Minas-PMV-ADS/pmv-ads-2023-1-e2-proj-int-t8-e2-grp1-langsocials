namespace Application.Common.Services.Files;

public class FileService : IFileService
{
    private static string Root => "wwwroot";
    public string DefaultUserImagePath => "Users/DefaultImage.png";

    public void DeleteImage(string imageURI)
    {
        var fullPath = Path.Combine(Root, imageURI);

        if (imageURI != DefaultUserImagePath)
            File.Delete(fullPath);
    }

    public string UpdateImage(string lastImage, string basePath, FileImage fileImage)
    {
        DeleteImage(lastImage);

        var fullPath = Path.Combine(basePath, fileImage.ImageName + fileImage.Extention);

        SaveImage(fullPath, fileImage.Image);

        return fullPath;
    }

    private static void SaveImage(string path, byte[] file)
    {
        var fullPath = Path.Combine(Root, path);
        File.WriteAllBytes(fullPath, file);
    }
}
