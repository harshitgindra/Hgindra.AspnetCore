using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class XssProtectionMiddleware : BaseMiddleware
    {
        public XssProtectionMiddleware(RequestDelegate next, IOptions<XssProtectionModel> options): base(next)
        {
            Key = "X-Xss-Protection";
            Value = options.Value.Value;
        }
    }
}
