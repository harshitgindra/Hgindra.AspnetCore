using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class ReferrerPolicyModel : BaseModel
    {
        /// <summary>
        /// Defines the parameters for the Referrer policy header with 'no-referrer' option set
        /// </summary>
        public ReferrerPolicyModel() : this(ReferrerPolicy.NoReferrer)
        {

        }

        /// <summary>
        /// Defines the parameters for the Referrer policy header with 'no-referrer' option set
        /// </summary>
        public ReferrerPolicyModel(ReferrerPolicy referrerPolicy)
        {
            this.ReferrerPolicy = referrerPolicy;
        }

        public ReferrerPolicy ReferrerPolicy { get; set; }

        internal override string Value
        {
            get
            {
                return ReferrerPolicy.DefaultValue();
            }
        }
    }

    public enum ReferrerPolicy
    {
        [DefaultValue("no-referrer")]
        [Description("Referrer information will not be sent with the request.")]
        NoReferrer = 0,

        [DefaultValue("no-referrer-when-downgrade")]
        [Description("The default setting where referrer is sent to the same protocol as HTTP to HTTP, HTTPS to HTTPS.")]
        NoReferrerWhenDowngrade = 1,

        [DefaultValue("same-origin")]
        [Description("Referrer will be sent only for same origin site.")]
        SameOrigin = 2,

        [DefaultValue("origin")]
        [Description("Send the origin URL in all the requests")]
        Origin = 3,

        [DefaultValue("strict-origin")]
        [Description("Send only when a protocol is HTTPS")]
        StrictOrigin = 4,

        [DefaultValue("origin-when-cross-origin")]
        [Description("Send FULL URL on the same origin. However, send only origin URL in other cases.")]
        OriginWhenCrossOrigin = 5,

        [DefaultValue("strict-origin-when-cross-origin")]
        [Description("The full URL will be sent over a strict protocol like HTTPS")]
        StrictOriginWhenCrossOrigin = 6,

        [DefaultValue("unsafe-url")]
        [Description("Full URL will be sent with the request.")]
        UnsafeUrl = 7,
    }
}
