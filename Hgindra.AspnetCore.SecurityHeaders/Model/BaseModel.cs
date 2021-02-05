namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class BaseModel
    {
        public BaseModel()
        {

        }

        public BaseModel(string key, string value)
        {
            this.Key = key;
            this.Value = value ?? string.Empty;
        }

        /// <summary>
        /// Header key
        /// </summary>
        public virtual string Key { get; }

        /// <summary>
        /// Header value
        /// </summary>
        public virtual string Value { get; }
    }
}
