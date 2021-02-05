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
        public static IApplicationBuilder AddXFrameOptionHeader(this IApplicationBuilder app)
        {
            app.UseMiddleware<XFrameOptionsMiddleware>();
            return app;
        }

        /// <summary>
        /// Add XFrameOptions security options to the header
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model"></param>
        public static IApplicationBuilder AddXFrameOptionHeader(this IApplicationBuilder app, XFrameOptionsModel model)
        {
            app.UseMiddleware<XFrameOptionsMiddleware>(new OptionsWrapper<XFrameOptionsModel>(model));
            return app;
        }

        /// <summary>
        /// Adds content type options to the headers
        /// This method will add header 'X-Content-Type-Options', 'nosniff'
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddContentTypeOptionHeader(this IApplicationBuilder app)
        {
            app.UseMiddleware<ContentTypeOptionsMiddleware>();
            return app;
        }

        /// <summary>
        /// Adds XSS Protection to the headers
        /// This method will add header 'X-Xss-Protection', '0'
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddXssProtectionHeader(this IApplicationBuilder app)
        {
            app.UseMiddleware<XssProtectionMiddleware>();
            return app;
        }

        /// <summary>
        /// Add XSS Protection security options to the header
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddXssProtectionHeader(this IApplicationBuilder app, XssProtectionModel model)
        {
            app.UseMiddleware<XssProtectionMiddleware>(new OptionsWrapper<XssProtectionModel>(model));
            return app;
        }

        /// <summary>
        /// Adds Referrer policy to the headers
        /// This method will add header 'Referrer-Policy', 'no-referrer'
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddReferrerPolicyHeader(this IApplicationBuilder app)
        {
            app.UseMiddleware<XssProtectionMiddleware>();
            return app;
        }

        /// <summary>
        /// Add Referrer policy options to the header
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddReferrerPolicyHeader(this IApplicationBuilder app, ReferrerPolicyModel model)
        {
            app.UseMiddleware<XssProtectionMiddleware>(new OptionsWrapper<ReferrerPolicyModel>(model));
            return app;
        }

        /// <summary>
        /// Adds Strict transport security to the headers
        /// This method will add header 'Strict-Transport-Security', 'max-age=31536000; includeSubDomains; preload'
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddStrictTransportSecurityHeader(this IApplicationBuilder app)
        {
            app.UseMiddleware<XssProtectionMiddleware>();
            return app;
        }

        /// <summary>
        /// Adds Strict transport security to the headers
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddStrictTransportSecurityHeader(this IApplicationBuilder app, StrictTransportSecurity model)
        {
            app.UseMiddleware<StrictTransportSecurityMiddleware>(new OptionsWrapper<StrictTransportSecurity>(model));
            return app;
        }

        /// <summary>
        /// Add custom header
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model"></param>
        public static IApplicationBuilder AddCustomHeader(this IApplicationBuilder app, string key, string value)
        {
            app.UseMiddleware<CustomHeaderMiddleware>(new OptionsWrapper<CustomHeaderModel>(new CustomHeaderModel(key, value)));
            return app;
        }
    }
}
