using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    /// <summary>
    /// The COEP header allows you to make sure that any cross-origin resources loaded by your page are explicitly permitted to be loaded with either CORS or CORP, or they will be blocked from loading.
    /// </summary>
    public class CrossOriginEmbedderPolicy : BaseModel
    {
        internal override string Value
        {
            get
            {
                string str = "(";
                if (RequireCorp)
                {
                    str += "require-corp";
                }
                else
                {
                    str += "unsafe-none";
                }

                str += ");";

                if (!string.IsNullOrEmpty(this.ReportTo))
                {
                    str += $" {this.ReportTo}";
                }

                return str;
            }
        }

        /// <summary>
        /// If you specify the require-corp value then a page can only load resources from the same origin or cross-origin
        /// </summary>
        public bool RequireCorp { get; set; }

        public string ReportTo { get; set; }
    }
}
