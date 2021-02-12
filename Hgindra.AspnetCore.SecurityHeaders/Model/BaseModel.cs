namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class BaseModel
    {
        internal BaseModel()
        {

        }

        protected BaseModel(string key, string value)
        {
            this.Key = key;
            this.Value = value ?? string.Empty;
        }

        /// <summary>
        /// Header key
        /// </summary>
        internal virtual string Key { get; }

        /// <summary>
        /// Header value
        /// </summary>
        internal virtual string Value { get; }

        /// <summary>
        /// specifies if the key needs to be removed
        /// </summary>
        internal virtual bool Remove { get; set; }
    }
}
