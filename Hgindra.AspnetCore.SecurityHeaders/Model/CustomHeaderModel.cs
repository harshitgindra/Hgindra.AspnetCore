namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class CustomHeaderModel : BaseModel
    {
        public CustomHeaderModel()
        {
        }

        public CustomHeaderModel(string key, string value)
        {
            this.Key = key;
            this.Value = value ?? string.Empty;
        }
    }
}
