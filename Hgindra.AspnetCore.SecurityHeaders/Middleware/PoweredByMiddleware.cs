using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class PoweredByMiddleware : BaseMiddleware
    {
        public PoweredByMiddleware(RequestDelegate next, IOptions<PoweredBy> options) : base(next)
        {
            this.Key = "X-Powered-By";
            this.RemoveKey = options.Value.Remove;
            this.Value = options.Value.Value;
        }
    }
}
