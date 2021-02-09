using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class PermissionPolicy : BaseModel
    {
        private string Convert(PermissionPolicyOption policy, string key)
        {
            if (policy != null)
            {
                string str = key;
                str += $"(";

                if (policy.AllowSelf || policy.Sources.Any())
                {
                    if (policy.AllowSelf)
                    {
                        str += $"self";
                    }

                    if (policy.Sources.Any())
                    {
                        str += $"\" {string.Join(" ", policy.Sources)} \"";
                    }
                }

                str += $")";

                return str;
            }

            return "";
        }

        internal override string Value
        {
            get
            {
                List<string> returnValue = new List<string>
                {
                    Convert(this.Camera, "camera"),
                    Convert(this.GeoLocation, "geolocation"),
                    Convert(this.FullScreen, "fullscreen"),
                    Convert(this.Microphone, "microphone"),
                    Convert(this.Speaker, "speaker"),
                    Convert(this.Vibrate, "vibrate")
                };

                return string.Join("; ", returnValue.Where(x => !string.IsNullOrEmpty(x)));
            }
        }

        /// <summary>
        /// Allows application to use full screen
        /// By Default, self attribute will be enabled
        /// </summary>
        public PermissionPolicyOption FullScreen { get; set; } = new PermissionPolicyOption();

        /// <summary>
        /// Allows application to use microphone
        /// Default = false
        /// </summary>
        public PermissionPolicyOption Microphone { get; set; } = new PermissionPolicyOption();

        /// <summary>
        /// Allows application to use vibrate
        /// Default = false
        /// </summary>
        public PermissionPolicyOption Vibrate { get; set; } = new PermissionPolicyOption();

        /// <summary>
        /// Allows application to use geo-location
        /// Default = false
        /// </summary>
        public PermissionPolicyOption GeoLocation { get; set; } = new PermissionPolicyOption();

        /// <summary>
        /// Allows application to use camera
        /// Default = false
        /// </summary>
        public PermissionPolicyOption Camera { get; set; } = new PermissionPolicyOption();

        /// <summary>
        /// Allows application to use speaker
        /// Default = false
        /// </summary>
        public PermissionPolicyOption Speaker { get; set; } = new PermissionPolicyOption();
    }

    public class PermissionPolicyOption
    {
        public PermissionPolicyOption()
        {
            this.Sources = new List<string>();
        }

        public bool AllowSelf { get; set; }

        public List<string> Sources { get; set; }
    }
}
