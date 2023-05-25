using Application.Common.LangSocialsDb.Extension;

namespace Application.Common.LangSocialsDb;

public interface IFileRepository
{
    string UserDefaultImage { get; }
    string UpdateUserImage(string lastImage, FileImage fileImage);
    void DeleteImage(string imageURI);
}
