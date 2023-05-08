using Microsoft.Extensions.Options;
using System.Web;

namespace LangSocials.Infraesctructure.LocationSearch;

public class GooglePlacesAPIAuthorizationMessageHandler : DelegatingHandler
{
    private readonly IOptions<GooglePlacesAPIOptions> options;

    public GooglePlacesAPIAuthorizationMessageHandler(IOptions<GooglePlacesAPIOptions> options)
    {
        this.options = options;
    }

    /// <summary>
    /// Before the request is actually sent, this adds an "key" query string with the API Key configured.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var requestedUri = request.RequestUri!.ToString();
        var parsedUri = HttpUtility.ParseQueryString(requestedUri);
        parsedUri["key"] = options.Value.ApiKey;
        request.RequestUri = new Uri(parsedUri.ToString()!);

        return base.SendAsync(request, cancellationToken);
    }
}
