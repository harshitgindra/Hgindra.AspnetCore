﻿using System;
using System.ComponentModel;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class XFrameOptionsModel : BaseModel
    {
        /// <summary>
        /// Defines the parameters for the X-Frame-Options header with the 'deny' option set
        /// </summary>
        public XFrameOptionsModel() : this(XFrameOptionsValues.Deny)
        {

        }

        /// <summary>
        /// Defines the parameters for the X-Frame-Options header sent in response to clients
        /// </summary>
        /// <param name="value">The Value to be applied to the header X-Frame-Options header</param>
        /// <param name="url">If ALLOW-FROM is selected, then this value is
        /// required and must have sited that are permitted to frame your site.
        /// Note: Chrome does not support the ALLOW-FROM option
        /// Null by default</param>
        public XFrameOptionsModel(XFrameOptionsValues xFrameOption, string url = null)
        {
            if (xFrameOption == XFrameOptionsValues.AllowFrom && string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("ALLOW-FROM URL string cannot be empty when ALLOW-FROM option is selected.");
            }

            XFrameOption = xFrameOption;
            Url = url;
        }

        /// <summary>
        /// Gets the predefined value to be applied to the header X-Frame-Options header.
        /// DENY is set by default.
        /// Note: Chrome does not support the ALLOW-FROM option
        /// </summary>
        public XFrameOptionsValues XFrameOption { get; set; }

        /// <summary>
        /// Gets the url allowed from a single domain.
        /// Note: Chrome does not support the ALLOW-FROM option
        /// </summary>
        public string Url { get; set; }

        public override string Value
        {
            get
            {
                if (this.XFrameOption == XFrameOptionsValues.AllowFrom)
                {
                    return $"{XFrameOption.DefaultValue()} {this.Url}";
                }

                return XFrameOption.DefaultValue();

            }
        }

        public override string Key
        {
            get
            {
                return "X-Frame-Options";
            }
        }
    }

    public enum XFrameOptionsValues
    {
        [DefaultValue("DENY")]
        Deny = 0,
        [DefaultValue("SAMEORIGIN")]
        SameOrigin = 1,
        [DefaultValue("ALLOW-FROM")]
        AllowFrom = 2
    }
}