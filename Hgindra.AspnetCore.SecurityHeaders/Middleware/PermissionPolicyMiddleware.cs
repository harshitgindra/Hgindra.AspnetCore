using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class PermissionPolicyMiddleware : BaseMiddleware
    {
        public PermissionPolicyMiddleware(RequestDelegate next, IOptions<PermissionPolicy> options) : base(next)
        {
            Key = "Permissions-Policy";
            Value = options.Value.Value;
        }
    }
}
