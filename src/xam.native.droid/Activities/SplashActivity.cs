using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using xam.native.core.ViewModels;

namespace xam.native.droid
{
    [Activity(
        Label = "Native Contacts Demo"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
public class SplashActivity : MvxActivity<SplashViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.splashscreen);
        }
    }
}