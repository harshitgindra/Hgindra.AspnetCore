using Microsoft.AspNetCore.Builder;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public static class Samples
    {
        public static void ConfigureSecurity(this IApplicationBuilder app)
        {
            #region X-Frame Options
            app.SetupXFrameOptions();

            app.SetupXFrameOptions(new XFrameOptionsModel()
            {
                Value = XFrameOptionsValues.AllowFrom,
                Url = ""
            });

            app.SetupXFrameOptions(new XFrameOptionsModel()
            {
                Value = XFrameOptionsValues.SameOrigin,
            }); 
            #endregion
        }
    }
}
