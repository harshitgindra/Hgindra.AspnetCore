using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Add XFrameOptions security options to the header
        /// </summary>
        /// <param name="app"></param>
        public static void SetupXFrameOptions(this IApplicationBuilder app)
        {
            app.UseMiddleware<XFrameOptionsMiddleware>();
        }

        /// <summary>
        /// Add XFrameOptions security options to the header
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model"></param>
        public static void SetupXFrameOptions(this IApplicationBuilder app, XFrameOptionsModel model)
        {
            app.UseMiddleware<XFrameOptionsMiddleware>(new OptionsWrapper<XFrameOptionsModel>(model));
        }
    }
}
