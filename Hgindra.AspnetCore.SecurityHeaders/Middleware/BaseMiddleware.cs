using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class BaseMiddleware
    {
        protected string Key { get; set; }
        protected string Value { get; set; }
        protected RequestDelegate Next { get; }

        public BaseMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public virtual async Task Invoke(HttpContext context)
        {
            //***
            //*** Check if header key is null/empty/whitespace
            //***
            if (string.IsNullOrEmpty(Key) || string.IsNullOrWhiteSpace(Key))
            {
                throw new ArgumentNullException("Header key is requied");
            }

            if (!ContainsKey(context.Response))
            {
                context.Response.Headers.Add(Key.Trim(), Value?.Trim() ?? string.Empty);
            }
            await Next(context);
        }

        protected bool ContainsKey(HttpResponse request)
        {
            return request.Headers.Any(x => x.Key.Equals(Key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
