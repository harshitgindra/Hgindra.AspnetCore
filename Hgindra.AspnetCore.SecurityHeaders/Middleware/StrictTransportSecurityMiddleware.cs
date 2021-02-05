using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class StrictTransportSecurityMiddleware : BaseMiddleware
    {
        public StrictTransportSecurityMiddleware(RequestDelegate next, IOptions<StrictTransportSecurity> options) : base(next)
        {
            Key = "Strict-Transport-Security";
            Value = options.Value.Value;
        }
    }
}
