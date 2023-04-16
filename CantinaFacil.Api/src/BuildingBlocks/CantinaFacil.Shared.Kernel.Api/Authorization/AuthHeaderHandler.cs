using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace CantinaFacil.Shared.Kernel.API.Authorization
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHeaderHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Replace("Bearer ", string.Empty));

            request.Headers.Add("x-cantinafacil-client", "insira-a-apiKey");

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
