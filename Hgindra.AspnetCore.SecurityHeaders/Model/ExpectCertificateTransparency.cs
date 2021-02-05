using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    /// <summary>
    /// Instruct the browser to validate the connection with web servers for certificate transparency (CT). 
    /// </summary>
    public class ExpectCertificateTransparency : BaseModel
    {
        /// <summary>
        /// In seconds, for how long the browser should cache the policy.
        /// Default = 43200
        /// </summary>
        public int MaxAge { get; set; } = 43200;

        /// <summary>
        /// An optional directive to enforce the policy.
        /// Default = true
        /// </summary>
        public bool Enforce { get; set; } = true;

        /// <summary>
        /// Browser to send a report to the specified URL when valid certificate transparency not received.
        /// </summary>
        public string ReportUrl { get; set; }

        internal override string Value
        {
            get
            {
                List<string> returnValue = new List<string>();

                if (Enforce)
                {
                    returnValue.Add($"enforce");
                }

                if (MaxAge != 0)
                {
                    returnValue.Add($"max-age={MaxAge}");
                }

                if (!string.IsNullOrEmpty(ReportUrl) && !string.IsNullOrWhiteSpace(this.ReportUrl))
                {
                    returnValue.Add($"report-uri=\"{this.ReportUrl}\"");
                }

                return string.Join(", ", returnValue);
            }
        }
    }
}
