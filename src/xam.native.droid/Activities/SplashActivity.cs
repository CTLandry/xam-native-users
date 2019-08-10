using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using xam.native.core;

namespace xam.native.droid
{
    [Activity(
        Label = "Native Contacts Demo"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
public class SplashActivity : MvxSplashScreenActivity<MvxAndroidSetup<App>, App>
{
    public SplashActivity()
         : base(Resource.Layout.splashscreen)
    {
    }
}
}