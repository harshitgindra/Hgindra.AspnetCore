using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class PermittedCrossDomainPoliciesMiddleware : BaseMiddleware
    {
        public PermittedCrossDomainPoliciesMiddleware(RequestDelegate next, IOptions<CustomHeaderModel> options) : base(next)
        {
            Key = "X-Permitted-Cross-Domain-Policies";

            if (options.Value == null)
            {
                Value = PermittedCrossDomainPolicy.None.DefaultValue();
            }
            else
            {
                Value = options.Value.Value;
            }
        }
    }
}
