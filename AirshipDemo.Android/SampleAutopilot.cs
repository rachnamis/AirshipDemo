using System;
using Android.Content;
using Android.Runtime;
using UrbanAirship;


namespace AirshipDemo.Droid
{
    [Register("com.urbanairship.AirshipDemo.SampleAutopilot")]
    public class SampleAutopilot : Autopilot
    {

        public override void OnAirshipReady(UAirship airship)
        {
            // perform any post takeOff airship customizations
        }
        public override AirshipConfigOptions CreateAirshipConfigOptions(Context context)
        {
            /* Optionally set your config at runtime */
            AirshipConfigOptions options = new AirshipConfigOptions.Builder()
               //  .SetInProduction(!BuildConfig.DEBUG)
                 .SetDevelopmentAppKey("GTPJTqqrS9CXa4uNlTSU9Q")
                 .SetDevelopmentAppSecret("rEj9urf4R3SkqkmMbXEWuA")
                 .SetProductionAppKey("Your Production App Key")
                 .SetProductionAppSecret("Your Production App Secret")
                 //.SetNotificationAccentColor(ContextCompat.getColor(this, R.color.color_accent))
                 //.SetNotificationIcon(R.drawable.ic_notification)
                 .Build();
            return options;
            //return base.CreateAirshipConfigOptions(context);
        }

    }
}