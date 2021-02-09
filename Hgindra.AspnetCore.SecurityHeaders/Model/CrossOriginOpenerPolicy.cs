using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CrossOriginOpenerPolicy : BaseModel
    {
        internal override string Value
        {
            get
            {
                string str = $"({this.Policy.DefaultValue()});";

                if (!string.IsNullOrEmpty(this.ReportTo))
                {
                    str += $" {this.ReportTo}";
                }

                return str;
            }
        }

        public CrossOriginOpenerPolicyOption Policy { get; set; }

        public string ReportTo { get; set; }
    }

    public enum CrossOriginOpenerPolicyOption
    {
        [DefaultValue("same-origin")]
        [Description("When setting the same-origin value, our page can only share a browsing context group with other pages from our own origin that have also set a COOP header ")]
        SameOrigin = 0,

        [DefaultValue("same-origin-allow-popups")]
        [Description("When using same-origin-allow-popups our page retains references to same-origin popups with unsafe-none either set explicitly or by default due to not having a policy, or that also have same-origin.")]
        SameOriginAllowPopups = 1,

        [DefaultValue("unsafe-none")]
        [Description("The final value of none will opt you out of COOP protections and is the default if no policy is set. This allows your page to be placed in the same browsing context groups as other pages unless they have protected themselves by enabling COOP.")]
        UnsafeNone = 2
    }
}
