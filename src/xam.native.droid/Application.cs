using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using System;
using xam.native.core;

namespace xam.native.droid
{
    [Application]
    public class Application : MvxAndroidApplication<MvxAndroidSetup<App>, App>
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Console.WriteLine("Android Setup Complete");
        }
    }
}
