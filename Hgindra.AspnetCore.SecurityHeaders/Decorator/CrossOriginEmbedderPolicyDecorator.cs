using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CrossOriginEmbedderPolicyDecorator
    {
        internal readonly CrossOriginEmbedderPolicy Policy = new CrossOriginEmbedderPolicy();

        public CrossOriginEmbedderPolicyDecorator RequireCorp()
        {
            this.Policy.RequireCorp = true;
            return this;
        }

        public CrossOriginEmbedderPolicyDecorator ReportTo(string str)
        {
            this.Policy.ReportTo = str;
            return this;
        }
    }
}
