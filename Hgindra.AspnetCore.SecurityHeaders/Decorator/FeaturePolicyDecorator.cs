using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class FeaturePolicyDecorator
    {
        internal readonly FeaturePolicy FeaturePolicy = new FeaturePolicy();

        public FeaturePolicyDecorator AllowGeolocation()
        {
            FeaturePolicy.AllowGeoLocation = true;
            return this;
        }
    }
}
