using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ContentSecurityPolicy : BaseModel
    {
        /// <summary>
        /// This defines the loading policy for all resources where the resource type dedicated directive is not defined (it’s the fallback). “Self” refers to your website’s domain.
        /// </summary>
        public ContentSecurityPolicyOptions Default { get; set; }

        /// <summary>
        /// Specifies valid sources for JavaScript
        /// </summary>
        public ContentSecurityPolicyOptions Scripts { get; set; }

        /// <summary>
        /// Specifies valid sources of images and favicons.
        /// </summary>
        public ContentSecurityPolicyOptions Images { get; set; }

        /// <summary>
        /// Specifies valid sources for stylesheets.
        /// </summary>
        public ContentSecurityPolicyOptions Stylesheets { get; set; }

        /// <summary>
        /// Specifies valid sources for fonts loaded using @font-face
        /// </summary>
        public ContentSecurityPolicyOptions Fonts { get; set; }

        /// <summary>
        /// This guards the browser mechanisms that can fetch HTTP Requests and only allows for requests to be made from your website.
        /// </summary>
        public ContentSecurityPolicyOptions Connect { get; set; }

        /// <summary>
        /// Specifies valid sources for nested browsing contexts loading using elements such as <frame> and <iframe>
        /// </summary>
        public ContentSecurityPolicyOptions Frames { get; set; }

        /// <summary>
        /// Specifies valid sources for loading media using the <audio>, <video> and <track> elements.
        /// </summary>
        public ContentSecurityPolicyOptions Media { get; set; }

        /// <summary>
        /// Always ensures that Nginx sends the header regardless of the response code.
        /// </summary>
        public bool AddAlways { get; set; }

        internal override string Value
        {
            get
            {
                string str = $"";

                str += Convert(Default, "default-src");

                str += Convert(Images, "img-src");

                str += Convert(Scripts, "script-src");

                str += Convert(Stylesheets, "style-src");

                str += Convert(Fonts, "font-src");

                str += Convert(Connect, "connect-src");

                str += Convert(Frames, "frame-src");

                str += Convert(Media, "media-src");

                str += $" ";
                if (this.AddAlways)
                {
                    str += "always;";
                }

                return str.Trim();
            }
        }

        private string Convert(ContentSecurityPolicyOptions option, string src)
        {
            string str = "";
            if (option != null)
            {
                str = $"{src} {option}; ";
            }
            return str;
        }
    }

    public class ContentSecurityPolicyOptions
    {
        public ContentSecurityPolicyOptions()
        {
            this.AdditionalSources = new List<string>();
        }
        /// <summary>
        /// This matches the current origin i.e. your domain name (but not subdomains).
        /// </summary>
        public bool Self { get; set; } = false;

        /// <summary>
        /// This allows the use of inline JS and CSS.
        /// </summary>
        public bool UnsafeInline { get; set; }

        /// <summary>
        /// This allows the use of mechanisms like eval().
        /// </summary>
        public bool UnsafeEval { get; set; }

        /// <summary>
        /// This prevents the browser from loading this type of resource.
        /// </summary>
        public bool None { get; set; }

        /// <summary>
        /// Specify any additional sources
        /// </summary>
        public List<string> AdditionalSources { get; set; }

        public override string ToString()
        {
            List<string> returnValue = new List<string>();

            if (this.Self)
            {
                returnValue.Add("'self'");
            }
            if (this.UnsafeInline)
            {
                returnValue.Add("'unsafe-inline'");
            }
            if (this.UnsafeEval)
            {
                returnValue.Add("'unsafe-eval'");
            }
            if (this.None)
            {
                returnValue.Add("'none'");
            }
            if (this.AdditionalSources != null && this.AdditionalSources.Any())
            {
                returnValue.AddRange(this.AdditionalSources);
            }

            return string.Join(" ", returnValue);
        }
    }

    public enum ContentSources
    {
        Self = 0,
        Inline = 1,
        Eval = 2,
    }
}
