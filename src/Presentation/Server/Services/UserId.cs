using Application.Common.Services;
using System.Security.Claims;

namespace LangSocials.Presentation.Server.Services;

public class UserId : IUserInfo
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserId(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }
    public int Id => int.Parse(httpContextAccessor.HttpContext?.User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
}
