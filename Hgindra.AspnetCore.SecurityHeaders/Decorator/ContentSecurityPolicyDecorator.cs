namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ContentSecurityPolicyDecorator
    {
        internal readonly ContentSecurityPolicy Policy = new ContentSecurityPolicy();

        public ContentSecurityPolicyOptionsDecorator AddScripts()
        {
            Policy.Scripts = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Scripts);
        }

        /// <summary>
        /// Specifies valid sources for nested browsing contexts loading using elements such as <frame> and <iframe>
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddFrames()
        {
            Policy.Frames = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Frames);
        }

        /// <summary>
        /// Specifies valid sources for stylesheets.
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddStylesheets()
        {
            Policy.Stylesheets = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Stylesheets);
        }

        /// <summary>
        /// Specifies valid sources for loading media using the <audio>, <video> and <track> elements.
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddMedia()
        {
            Policy.Media = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Media);
        }

        /// <summary>
        /// This guards the browser mechanisms that can fetch HTTP Requests and only allows for requests to be made from your website.
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddConnect()
        {
            Policy.Connect = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Connect);
        }

        /// <summary>
        /// Specifies valid sources of images and favicons.
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddImages()
        {
            Policy.Images = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Images);
        }

        /// <summary>
        /// Specifies valid sources for fonts loaded using @font-face
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddFonts()
        {
            Policy.Fonts = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Fonts);
        }

        /// <summary>
        /// This defines the loading policy for all resources where the resource type dedicated directive is not defined (it’s the fallback). “Self” refers to your website’s domain.
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddDefault()
        {
            Policy.Default = new ContentSecurityPolicyOptions();
            return new ContentSecurityPolicyOptionsDecorator(Policy.Default);
        }

        /// <summary>
        /// Always ensures that Nginx sends the header regardless of the response code.
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyDecorator AddAlways()
        {
            Policy.AddAlways = true;
            return this;
        }
    }

    public class ContentSecurityPolicyOptionsDecorator
    {
        internal readonly ContentSecurityPolicyOptions Option;

        public ContentSecurityPolicyOptionsDecorator(ContentSecurityPolicyOptions option)
        {
            this.Option = option;
        }

        /// <summary>
        /// This matches the current origin i.e. your domain name (but not subdomains). Default is false
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AllowSelf()
        {
            Option.Self = true;
            return this;
        }

        /// <summary>
        /// This prevents the browser from loading this type of resource. Default is allow all
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator DenyAll()
        {
            Option.None = true;
            return this;
        }

        /// <summary>
        /// This allows the use of inline JS and CSS. Default is false
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AllowInline()
        {
            Option.UnsafeInline = true;
            return this;
        }

        /// <summary>
        /// This allows the use of mechanisms like eval(). Default is false
        /// </summary>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AllowEval()
        {
            Option.UnsafeEval = true;
            return this;
        }

        /// <summary>
        /// Specify any additional sources
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public ContentSecurityPolicyOptionsDecorator AddSource(string src)
        {
            if (!string.IsNullOrEmpty(src))
            {
                Option.AdditionalSources.Add(src.Trim());
            }

            return this;
        }
    }
}
