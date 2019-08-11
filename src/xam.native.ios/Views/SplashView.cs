using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using xam.native.core.ViewModels;

namespace xam.native.ios.Views
{
    public partial class SplashView : MvxViewController<SplashViewModel>
    {
        public SplashView() : base("SplashView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<SplashView, SplashViewModel>();
            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

