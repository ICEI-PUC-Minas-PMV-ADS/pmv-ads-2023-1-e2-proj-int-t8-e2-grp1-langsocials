using Application.Common.Services;
using LangSocials.Domain.Entities;
using System.Security.Claims;

namespace LangSocials.Presentation.Server.Services;

public class HttpContextUserInfo : IUserInfo
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public HttpContextUserInfo(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }
    public int Id => int.Parse(httpContextAccessor.HttpContext?.User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

    public Location? SearchLocation => throw new NotImplementedException(); // TODO: Implementar meio de obter localizacao de pesquisa
}
