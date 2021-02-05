using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public enum PermittedCrossDomainPolicy
    {
        [DefaultValue("none")]
        [Description("No policy is allowed")]
        None = 0,

        [DefaultValue("master-only")]
        [Description("Allow only the master policy")]
        MasterOnly = 1,

        [DefaultValue("all")]
        [Description("Everything is allowed")]
        All = 2,

        [DefaultValue("by-content-only")]
        [Description("Allow only a certain type of content. Example – XML")]
        ByContentOnly = 3,

        [DefaultValue("by-ftp-only")]
        [Description("Applicable only for an FTP server")]
        ByFtpOnly = 4,
    }
}
