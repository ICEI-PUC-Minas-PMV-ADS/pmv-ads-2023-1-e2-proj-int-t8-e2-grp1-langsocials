using LangSocials.Domain.Entities;

namespace Application.Common.Services;

public interface IUserInfo
{
    int Id { get; }

    Location? SearchLocation { get; }
}
