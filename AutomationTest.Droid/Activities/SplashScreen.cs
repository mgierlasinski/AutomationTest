using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace AutomationTest.Droid.Activities
{
    [Activity(
        MainLauncher = true,
        Theme = "@style/SplashScreen",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
        {
        }
    }
}