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

    // TODO: Implementar meio de obter localizacao de pesquisa
    public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
