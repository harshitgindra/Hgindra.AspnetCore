using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class StrictTransportSecurity : BaseModel
    {
        /// <summary>
        /// Defines the parameters for the Strict-Transport-Security header
        /// </summary>
        public StrictTransportSecurity()
        {

        }

        /// <summary>
        /// Defines the parameters for the Strict-Transport-Security header
        /// </summary>
        public StrictTransportSecurity(int maxAge, bool includeSubDomains, bool preload)
        {
            this.MaxAge = maxAge;
            this.IncludeSubDomains = includeSubDomains;
            this.Preload = preload;
        }

        /// <summary>
        /// Duration (in seconds) to tell a browser that requests are available only over HTTPS.
        /// Default = 30 days
        /// </summary>
        public int MaxAge { get; set; } = 60 * 60 * 24 * 30;

        /// <summary>
        /// The configuration is valid for the subdomain as well.
        /// Default true
        /// </summary>
        public bool IncludeSubDomains { get; set; } = true;

        /// <summary>
        /// Use if you would like your domain to be included in the HSTS preload list
        /// Default true
        /// </summary>
        public bool Preload { get; set; } = true;

        internal override string Value
        {
            get
            {
                List<string> returnValue = new List<string>();

                if (MaxAge != 0)
                {
                    returnValue.Add($"max-age={MaxAge}");
                }

                if (IncludeSubDomains)
                {
                    returnValue.Add($"includeSubDomains");
                }

                if (Preload)
                {
                    returnValue.Add($"preload");
                }

                return string.Join("; ", returnValue);
            }
        }
    }
}
