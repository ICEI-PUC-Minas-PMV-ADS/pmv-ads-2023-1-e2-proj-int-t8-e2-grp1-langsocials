using LangSocials.Domain.Entities;

namespace Application.Common.Services;

public interface IUserInfo
{
    int Id { get; }
    string City { get; set; }
    string State { get; set; }
}
