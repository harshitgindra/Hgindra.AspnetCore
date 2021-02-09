using Hgindra.AspnetCore.SecurityHeaders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hgindra.AspnetCore.SecurityHeaders
{
    public class PermissionPolicyDecorator
    {
        internal readonly PermissionPolicy Policy = new PermissionPolicy();

        /// <summary>
        /// Configure permission policies for geolocation
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator ConfigureGeoLocation()
        {
            Policy.GeoLocation = new PermissionPolicyOption();
            return new PermissionPolicySettingDecorator(Policy.GeoLocation);
        }
        /// <summary>
        /// Configure permission policies for camera
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator ConfigureCamera()
        {
            Policy.Camera = new PermissionPolicyOption();
            return new PermissionPolicySettingDecorator(Policy.Camera);
        }
        /// <summary>
        /// Configure permission policies for speaker
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator ConfigureSpeaker()
        {
            Policy.Speaker = new PermissionPolicyOption();
            return new PermissionPolicySettingDecorator(Policy.Speaker);
        }

        /// <summary>
        /// Configure permission policies for vibrate
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator ConfigureVibrate()
        {
            Policy.Vibrate = new PermissionPolicyOption();
            return new PermissionPolicySettingDecorator(Policy.Vibrate);
        }

        /// <summary>
        /// Configure permission policies for FullScreen
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator ConfigureFullScreen()
        {
            Policy.FullScreen = new PermissionPolicyOption();
            return new PermissionPolicySettingDecorator(Policy.FullScreen);
        }

        /// <summary>
        /// Configure permission policies for Microphone
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator ConfigureMicrophone()
        {
            Policy.Microphone = new PermissionPolicyOption();
            return new PermissionPolicySettingDecorator(Policy.Microphone);
        }
    }

    public class PermissionPolicySettingDecorator
    {
        internal PermissionPolicyOption PermissionPolicyOption { get; }

        public PermissionPolicySettingDecorator(PermissionPolicyOption permissionPolicyOption)
        {
            PermissionPolicyOption = permissionPolicyOption;
        }

        /// <summary>
        /// Allow self source
        /// </summary>
        /// <returns></returns>
        public PermissionPolicySettingDecorator AllowSelf()
        {
            this.PermissionPolicyOption.AllowSelf = true;
            return this;
        }
        /// <summary>
        /// Add source for permission policy
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public PermissionPolicySettingDecorator AddSource(string uri)
        {
            this.PermissionPolicyOption.Sources.Add(uri);
            return this;
        }
    }
}


