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

            #region Custom header
            app.AddCustomHeader("header key", "header value");
            #endregion
        }
    }
}
