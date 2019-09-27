using Android.App;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace AutomationTest.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MenuView : MvxAppCompatActivity<MenuViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuView);
        }
    }
}