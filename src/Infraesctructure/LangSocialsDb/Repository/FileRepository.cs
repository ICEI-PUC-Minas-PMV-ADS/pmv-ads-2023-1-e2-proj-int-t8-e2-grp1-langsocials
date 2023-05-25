using Application.Common.LangSocialsDb;
using Application.Common.LangSocialsDb.Extension;

namespace LangSocials.Infraesctructure.LangSocialsDb.Repository;

 public class FileRepository : IFileRepository
{
    private static string Root => "wwwroot";
    public string UserDefaultImage => "Users/DefaultImage.png";

    public void DeleteImage(string imageURI)
    {
        if (imageURI != UserDefaultImage)
            File.Delete($"{Root}/{imageURI}");
    }

    public string UpdateUserImage(string lastImage, FileImage fileImage)
    {
        DeleteImage(lastImage);

        var path = $"/Users/{fileImage.ImageName}{fileImage.Extention}";

        SaveImage(path, fileImage.Image);

        return path;
    }

    private static void SaveImage(string path, byte[] file)
        => File.WriteAllBytes($"{Root}/{path}", file);
}
