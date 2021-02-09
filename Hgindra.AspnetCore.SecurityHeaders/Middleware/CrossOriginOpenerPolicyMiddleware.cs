using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CrossOriginOpenerPolicyMiddleware : BaseMiddleware
    {
        public CrossOriginOpenerPolicyMiddleware(RequestDelegate next, IOptions<CrossOriginEmbedderPolicy> options) : base(next)
        {
            Key = "Cross-Origin-Opener-Policy";
            Value = options.Value.Value;
        }
    }
}
