using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using UrbanAirship;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Firebase;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Gms.Common;

namespace AirshipDemo.Droid
{
    [Activity(Label = "AirshipDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Airship must be initialized before Application is loaded.

            

            Autopilot.AutomaticTakeOff(this.ApplicationContext);

            base.OnCreate(savedInstanceState);
            IsPlayServicesAvailable();
            FirebaseApp.InitializeApp(this.ApplicationContext);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());

            UAirship.Shared().PushManager.UserNotificationsEnabled = true;

        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                { }
                // msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    //msgText.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                //msgText.Text = "Google Play Services is available.";
                return true;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}