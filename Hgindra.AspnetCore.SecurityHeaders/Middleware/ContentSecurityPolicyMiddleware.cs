using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ContentSecurityPolicyMiddleware : BaseMiddleware
    {
        public ContentSecurityPolicyMiddleware(RequestDelegate next, IOptions<ContentSecurityPolicy> options) : base(next)
        {
            Key = "Content-Security-Policy";
            Value = options.Value.Value;
        }
    }
}
