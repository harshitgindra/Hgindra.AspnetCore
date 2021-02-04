namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class BaseModel
    {
        /// <summary>
        /// Header key
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// Header value
        /// </summary>
        public virtual string Value { get; set; }
    }
}
