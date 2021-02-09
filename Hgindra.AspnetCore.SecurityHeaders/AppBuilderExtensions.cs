using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

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
        /// Prevent MIME types of security risk by adding this header to your web page’s HTTP response. Having this header instructs browser to consider file types as defined and disallow content sniffing.
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
        /// Add Referrer policy options to the header
        /// By default This method will add header 'Referrer-Policy', 'no-referrer'
        /// </summary>
        /// <param name="policy">Referrer policy, default set to no-referrer</param>
        public static IApplicationBuilder AddReferrerPolicyHeader(this IApplicationBuilder app, ReferrerPolicy policy = ReferrerPolicy.NoReferrer)
        {
            app.UseMiddleware<ReferrerPolicyMiddleware>(new OptionsWrapper<ReferrerPolicyModel>(new ReferrerPolicyModel(policy)));
            return app;
        }

        /// <summary>
        /// HTTP Strict Transport Security is an excellent feature to support on your site and strengthens your implementation of TLS. That said, the HSTS header must not be returned over a HTTP connection, only HTTPS.
        /// This method will add header 'Strict-Transport-Security', 'max-age=31536000; includeSubDomains; preload' by default
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder AddStrictTransportSecurityHeader(this IApplicationBuilder app, StrictTransportSecurity model = null)
        {
            app.UseMiddleware<StrictTransportSecurityMiddleware>(new OptionsWrapper<StrictTransportSecurity>(model ?? new StrictTransportSecurity()));
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

        /// <summary>
        /// It instruct the browser how to handle the requests over a cross-domain. By implementing this header, you restrict loading your site’s assets from other domains to avoid resource abuse
        /// By default This method will add header 'X-Permitted-Cross-Domain-Policies', 'none'
        /// </summary>
        /// <param name="app"></param>
        /// <param name="permittedCrossDomainPolicy">Permitted Cross Domain Policies</param>
        public static IApplicationBuilder AddPermittedCrossDomainPolicyHeader(this IApplicationBuilder app, PermittedCrossDomainPolicy permittedCrossDomainPolicy = PermittedCrossDomainPolicy.None)
        {
            app.UseMiddleware<PermittedCrossDomainPoliciesMiddleware>(new OptionsWrapper<CustomHeaderModel>(new CustomHeaderModel(string.Empty, permittedCrossDomainPolicy.DefaultValue())));
            return app;
        }


        /// <summary>
        /// Expect-CT allows a site to determine if they are ready for the upcoming Chrome requirements and/or enforce their CT policy, but it should not be sent over HTTP.
        /// This method will add header 'Expect-CT', 'enforce, max-age=43200' by default
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        public static IApplicationBuilder AddExpectCertificateTransparencyHeader(this IApplicationBuilder app, ExpectCertificateTransparency model = null)
        {
            app.UseMiddleware<ExpectCertificateTransparencyMiddleware>(new OptionsWrapper<ExpectCertificateTransparency>(model ?? new ExpectCertificateTransparency()));
            return app;
        }


        /// <summary>
        /// Control browser’s features such as geolocation, fullscreen, speaker, USB, autoplay, speaker, vibrate, microphone, payment, vr, etc. to enable or disable within a web application.
        /// Eg. This method will add header 'Feature-Policy', 'fullscreen 'none'; microphone 'none''
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        [Obsolete("Use permission policy instead")]
        public static IApplicationBuilder AddFeaturePolicyHeader(this IApplicationBuilder app, FeaturePolicy model)
        {
            app.UseMiddleware<FeaturePolicyMiddleware>(new OptionsWrapper<FeaturePolicy>(model ?? new FeaturePolicy()));
            return app;
        }

        /// <summary>
        /// Control browser’s features such as geolocation, fullscreen, speaker, USB, autoplay, speaker, vibrate, microphone, payment, vr, etc. to enable or disable within a web application.
        /// Eg. This method will add header 'Feature-Policy', 'fullscreen 'none'; microphone 'none''
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        [Obsolete("Use permission policy instead")]
        public static IApplicationBuilder AddFeaturePolicyHeader(this IApplicationBuilder app, Action<FeaturePolicyDecorator> model = null)
        {
            var builder = new FeaturePolicyDecorator();
            if (model != null)
            {
                model(builder);
            }

            app.UseMiddleware<FeaturePolicyMiddleware>(new OptionsWrapper<FeaturePolicy>(builder.FeaturePolicy));
            return app;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy response header allows web site administrators to control resources the user agent is allowed to load for a given page. With a few exceptions, policies mostly involve specifying server origins and script endpoints. This helps guard against cross-site scripting attacks (XSS).
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        public static IApplicationBuilder AddContentSecurityPolicyHeader(this IApplicationBuilder app, Action<ContentSecurityPolicyDecorator> model = null)
        {
            var builder = new ContentSecurityPolicyDecorator();
            model?.Invoke(builder);

            app.UseMiddleware<ContentSecurityPolicyMiddleware>(new OptionsWrapper<ContentSecurityPolicy>(builder.Policy));
            return app;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy response header allows web site administrators to control resources the user agent is allowed to load for a given page. With a few exceptions, policies mostly involve specifying server origins and script endpoints. This helps guard against cross-site scripting attacks (XSS).
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        public static IApplicationBuilder AddPermissionPolicyHeader(this IApplicationBuilder app, Action<PermissionPolicyDecorator> model = null)
        {
            var builder = new PermissionPolicyDecorator();
            model?.Invoke(builder);

            app.UseMiddleware<PermissionPolicyMiddleware>(new OptionsWrapper<PermissionPolicy>(builder.Policy));
            return app;
        }

        /// <summary>
        /// The COEP header allows you to make sure that any cross-origin resources loaded by your page are explicitly permitted to be loaded with either CORS or CORP, or they will be blocked from loading.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        public static IApplicationBuilder AddCrossOriginEmbedderPolicyHeader(this IApplicationBuilder app, Action<CrossOriginEmbedderPolicyDecorator> model = null)
        {
            var builder = new CrossOriginEmbedderPolicyDecorator();
            model?.Invoke(builder);

            app.UseMiddleware<PermissionPolicyMiddleware>(new OptionsWrapper<CrossOriginEmbedderPolicy>(builder.Policy));
            return app;
        }

        /// <summary>
        /// The COOP header allows you to break out of the Browsing Context Group for your page and ensure you do not share one with a potentially hostile origin. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="model">Expect Certificate Transparency details</param>
        public static IApplicationBuilder AddCrossOriginOpenerPolicyHeader(this IApplicationBuilder app, Action<CrossOriginOpenerPolicyDecorator> model = null)
        {
            var builder = new CrossOriginOpenerPolicyDecorator();
            model?.Invoke(builder);

            app.UseMiddleware<CrossOriginOpenerPolicyMiddleware>(new OptionsWrapper<CrossOriginOpenerPolicy>(builder.Policy));
            return app;
        }
    }
}
