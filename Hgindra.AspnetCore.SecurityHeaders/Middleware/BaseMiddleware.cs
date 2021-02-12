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
        protected bool RemoveKey { get; set; }

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

            //***
            //*** Check if key already exists and remove key flag is set to false
            //***
            if (!ContainsKey(context.Response) && !RemoveKey)
            {
                context.Response.Headers.Add(Key.Trim(), Value?.Trim() ?? string.Empty);
            }
            else
            {
                if (RemoveKey)
                {
                    //***
                    //*** Remove the key
                    //***
                    context.Response.Headers.Remove(Key.Trim());
                }
                else
                {
                    //***
                    //*** Key already exists, replace the value
                    //***
                    context.Response.Headers[Key.Trim()] = Value?.Trim() ?? string.Empty;
                }
            }

            await Next(context);
        }

        protected bool ContainsKey(HttpResponse request)
        {
            return request.Headers.Any(x => x.Key.Equals(Key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
