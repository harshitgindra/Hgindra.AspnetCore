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
        NoReferrer = 0, 
        [DefaultValue("no-referrer-when-downgrade")]
        NoReferrerWhenDowngrade = 1,
        [DefaultValue("same-origin")]
        SameOrigin = 2,
        [DefaultValue("origin")]
        Origin = 3,
        [DefaultValue("strict-origin")]
        StrictOrigin = 4,
        [DefaultValue("origin-when-cross-origin")]
        OriginWhenCrossOrigin = 5,
        [DefaultValue("strict-origin-when-cross-origin")]
        StrictOriginWhenCrossOrigin = 6,
        [DefaultValue("unsafe-url")]
        UnsafeUrl = 7,
    }
}
