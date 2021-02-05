using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class XssProtectionModel : BaseModel
    {
        /// <summary>
        /// Defines the parameters for the X-Xss-Protection header with the '0' option set
        /// </summary>
        public XssProtectionModel()
        {

        }

        /// <summary>
        /// Enables XSS filtering (usually default in browsers). If a cross-site scripting attack is detected, the browser will sanitize the page (remove the unsafe parts). Default is false
        /// </summary>
        public bool EnableXssFiltering { get; set; }

        /// <summary>
        /// When set to true, rather than sanitizing the page, the browser will prevent rendering of the page if an attack is detected. Default is false
        /// </summary>
        public bool Block { get; set; }

        /// <summary>
        /// Enables XSS filtering. If a cross-site scripting attack is detected, the browser will sanitize the page and report the violation. This uses the functionality of the CSP report-uri directive to send a report.
        /// Eg. http://example.com/report_URI
        /// </summary>
        public string ReportUri { get; set; }

        internal override string Value
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ReportUri) && !string.IsNullOrWhiteSpace(this.ReportUri))
                {
                    return $"1; report={this.ReportUri.Trim()}";
                }
                else if (this.Block)
                {
                    return $"1; mode=block";
                }
                else if (this.EnableXssFiltering)
                {
                    return $"1";
                }
                else
                {
                    return "0";
                }
            }
        }
    }
}
