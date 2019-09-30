using Android.Widget;
using AutomationTest.Core.Services;
using MvvmCross.Platforms.Android;

namespace AutomationTest.Droid.Services
{
    public class PopupService : IPopupService
    {
        private readonly IMvxAndroidCurrentTopActivity _activity;

        public PopupService(IMvxAndroidCurrentTopActivity activity)
        {
            _activity = activity;
        }

        public void ShowToast(string message)
        {
            Toast.MakeText(_activity.Activity, message, ToastLength.Long).Show();
        }
    }
}