using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class BaseMiddleware
    {
        protected string HeaderKey { get; set; }
        protected string HeaderValue { get; set; }
        protected RequestDelegate Next { get; }

        public BaseMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public virtual async Task Invoke(HttpContext context)
        {
            if (!ContainsKey(context.Response))
            {
                context.Response.Headers.Add(HeaderKey, HeaderValue);
            }
            await Next(context);
        }

        protected bool ContainsKey(HttpResponse request)
        {
            return request.Headers.Any(x => x.Key.Equals(HeaderKey, StringComparison.OrdinalIgnoreCase));
        }
    }
}
