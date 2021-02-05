using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ReferrerPolicyMiddleware : BaseMiddleware
    {
        public ReferrerPolicyMiddleware(RequestDelegate next, IOptions<ReferrerPolicyModel> options) : base(next)
        {
            Key = "Referrer-Policy";
            Value = options.Value.Value;
        }
    }
}
