using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CrossOriginOpenerPolicyDecorator
    {
        internal readonly CrossOriginOpenerPolicy Policy = new CrossOriginOpenerPolicy();

        public CrossOriginOpenerPolicyDecorator ConfigurePolicy(CrossOriginOpenerPolicyOption policyOption)
        {
            this.Policy.Policy = policyOption;
            return this;
        }

        public CrossOriginOpenerPolicyDecorator ReportTo(string str)
        {
            this.Policy.ReportTo = str;
            return this;
        }
    }
}
