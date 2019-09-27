using Android.App;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace AutomationTest.Droid.Views
{
    [Activity(Label = "Automation Test", MainLauncher = true)]
    public class MenuView : MvxActivity<MenuViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuView);
        }
    }
}