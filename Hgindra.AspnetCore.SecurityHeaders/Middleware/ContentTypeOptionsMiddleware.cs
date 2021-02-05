using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ContentTypeOptionsMiddleware : BaseMiddleware
    {
        public ContentTypeOptionsMiddleware(RequestDelegate next, IOptions<XFrameOptionsModel> options): base(next)
        {
            Key = "X-Content-Type-Options";
            Value = "nosniff";
        }
    }
}
