namespace Application.Common.Services.Files;

public interface IFileService
{
    string DefaultUserImagePath { get; }
    string UpdateImage(string lastImage, string basePath, FileImage fileImage);
    void DeleteImage(string imageURI);
}
