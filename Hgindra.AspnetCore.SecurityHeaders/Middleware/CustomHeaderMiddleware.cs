using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CustomHeaderMiddleware : BaseMiddleware
    {
        public CustomHeaderMiddleware(RequestDelegate next, IOptions<CustomHeaderModel> options) : base(next)
        {
            Key = options.Value.Key;
            Value = options.Value.Value;
        }
    }
}
