using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class FeaturePolicyMiddleware : BaseMiddleware
    {
        public FeaturePolicyMiddleware(RequestDelegate next, IOptions<FeaturePolicy> options) : base(next)
        {
            Key = "Feature-Policy";
            Value = options.Value.Value;
        }
    }
}
