using Android.App;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace AutomationTest.Droid.Views
{
    [Activity]
    public class PackageDimmsView : MvxActivity<PackageDimmsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PackageDimmsView);
        }
    }
}