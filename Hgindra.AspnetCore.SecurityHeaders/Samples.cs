using Microsoft.AspNetCore.Builder;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public static class Samples
    {
        public static void ConfigureSecurity(this IApplicationBuilder app)
        {
            #region X-Frame Options
            app.AddXFrameOptionHeader();

            app.AddXFrameOptionHeader(new XFrameOptionsModel()
            {
                XFrameOption = XFrameOptionsValues.AllowFrom,
                Url = "your url"
            });

            app.AddXFrameOptionHeader(new XFrameOptionsModel()
            {
                XFrameOption = XFrameOptionsValues.SameOrigin,
            });
            #endregion

            #region Referrer Policies
            app.AddReferrerPolicyHeader();

            app.AddReferrerPolicyHeader(new ReferrerPolicyModel()
            {
                ReferrerPolicy = ReferrerPolicy.NoReferrerWhenDowngrade
            });

            #endregion

            #region Strict transport security
            app.AddStrictTransportSecurityHeader();

            app.AddStrictTransportSecurityHeader(new StrictTransportSecurity()
            {
                MaxAge = 1,
                IncludeSubDomains = true,
                Preload = true
            });

            #endregion

            #region XSS Protection
            app.AddXssProtectionHeader();

            app.AddXssProtectionHeader(new XssProtectionModel()
            {
                Block = true,
                EnableXssFiltering = true,
            });

            app.AddXssProtectionHeader(new XssProtectionModel()
            {
                ReportUri = "",
                EnableXssFiltering = true,
            });
            #endregion

            #region Content type options 
            app.AddContentTypeOptionHeader();
            #endregion

            #region Expect certificate transparency 
            app.AddExpectCertificateTransparencyHeader();

            app.AddExpectCertificateTransparencyHeader(new ExpectCertificateTransparency()
            {
                MaxAge = 10,
                Enforce = true,
                ReportUrl = "abc.com"
            });
            #endregion

            #region Permitted cross domain policy header 
            app.AddPermittedCrossDomainPolicyHeader();

            app.AddPermittedCrossDomainPolicyHeader(PermittedCrossDomainPolicy.All);
            #endregion

            #region Custom header
            app.AddCustomHeader("header key", "header value");
            #endregion
        }
    }
}
