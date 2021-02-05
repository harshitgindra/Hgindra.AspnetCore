using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ExpectCertificateTransparencyMiddleware : BaseMiddleware
    {
        public ExpectCertificateTransparencyMiddleware(RequestDelegate next, IOptions<ExpectCertificateTransparency> options) : base(next)
        {
            Key = "Expect-CT";
            Value = options.Value.Value;
        }
    }
}
