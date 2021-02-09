using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CrossOriginEmbedderPolicyMiddleware : BaseMiddleware
    {
        public CrossOriginEmbedderPolicyMiddleware(RequestDelegate next, IOptions<CrossOriginEmbedderPolicy> options) : base(next)
        {
            Key = "Cross-Origin-Embedder-Policy";
            Value = options.Value.Value;
        }
    }
}
