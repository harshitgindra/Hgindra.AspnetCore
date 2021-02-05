using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class FeaturePolicy : BaseModel
    {
        internal override string Value
        {
            get
            {
                List<string> returnValue = new List<string>();

                if (!this.AllowGeoLocation)
                {
                    returnValue.Add($"geolocation 'none'");
                }

                if (!this.AllowCamera)
                {
                    returnValue.Add($"camera 'none'");
                }

                if (!this.AllowSpeaker)
                {
                    returnValue.Add($"speaker 'none'");
                }

                if (!this.AllowVibrate)
                {
                    returnValue.Add($"vibrate 'none'");
                }

                if (!this.AllowFullScreen)
                {
                    returnValue.Add($"fullscreen 'none'");
                }

                if (!this.AllowMicrophone)
                {
                    returnValue.Add($"microphone 'none'");
                }

                return string.Join("; ", returnValue);
            }
        }

        /// <summary>
        /// Allows application to use full screen
        /// Default = true
        /// </summary>
        public bool AllowFullScreen { get; set; } = true;

        /// <summary>
        /// Allows application to use microphone
        /// Default = false
        /// </summary>
        public bool AllowMicrophone { get; set; } = false;

        /// <summary>
        /// Allows application to use vibrate
        /// Default = false
        /// </summary>
        public bool AllowVibrate { get; set; } = false;

        /// <summary>
        /// Allows application to use geo-location
        /// Default = false
        /// </summary>
        public bool AllowGeoLocation { get; set; } = false;

        /// <summary>
        /// Allows application to use camera
        /// Default = false
        /// </summary>
        public bool AllowCamera { get; set; } = false;

        /// <summary>
        /// Allows application to use speaker
        /// Default = false
        /// </summary>
        public bool AllowSpeaker { get; set; } = false;
    }
}
