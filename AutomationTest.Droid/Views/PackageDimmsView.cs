using Android.App;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace AutomationTest.Droid.Views
{
    [Activity]
    public class PackageDimmsView : MvxAppCompatActivity<PackageDimmsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PackageDimmsView);
        }
    }
}