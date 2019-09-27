using Android.App;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace AutomationTest.Droid.Views
{
    [Activity]
    public class PackageListView : MvxAppCompatActivity<PackageListViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PackageListView);
        }
    }
}