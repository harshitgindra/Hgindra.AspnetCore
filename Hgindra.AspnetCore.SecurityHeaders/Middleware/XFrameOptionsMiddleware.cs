using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class XFrameOptionsMiddleware: BaseMiddleware
    {
        public XFrameOptionsMiddleware(RequestDelegate next, IOptions<XFrameOptionsModel> options): base(next)
        {
            Key = "X-Frame-Options";
            Value = options.Value.Value;
        }
    }
}
