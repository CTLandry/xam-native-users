
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using xam.native.core.ViewModels;

namespace xam.native.droid.Activities
{
    [Activity(Label = "Contacts List")]
    public class ContactsListActivity : MvxActivity<ContactListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.userlist);
        }
    }
}
