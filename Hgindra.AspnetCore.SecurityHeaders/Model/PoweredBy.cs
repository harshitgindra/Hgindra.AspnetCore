namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class PoweredBy : BaseModel
    {
        internal string PoweredByValue { get; set; }

        internal override string Value
        {
            get
            {
                if (this.Remove)
                {
                    return string.Empty;
                }
                else
                {
                    return this.PoweredByValue;
                }
            }
        }
    }
}
