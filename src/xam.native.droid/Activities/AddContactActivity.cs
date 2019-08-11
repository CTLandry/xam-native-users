using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using xam.native.core.ViewModels;

namespace xam.native.droid.Activities
{
    [Activity(Label = "Add Contact")]
    public class AddContactActivity : MvxActivity<AddContactViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.addcontact);
        }
    }
}
