namespace Hgindra.AspnetCore.SecurityHeaders
{
    /// <summary>
    /// "X-Powered-By" is a common non-standard HTTP response header (most headers prefixed with an 'X-' are non-standard). It's often included by default in responses constructed via a particular scripting technology.
    /// </summary>
    public class PoweredByDecorator
    {
        internal readonly PoweredBy Policy = new PoweredBy();

        /// <summary>
        /// Set value for powered by header in the request
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public PoweredByDecorator SetValue(string value)
        {
            Policy.PoweredByValue = value;
            return this;
        }

        /// <summary>
        /// Removes the header from the request
        /// </summary>
        /// <returns></returns>
        public PoweredByDecorator Remove()
        {
            Policy.Remove = true;
            return this;
        }
    }
}
