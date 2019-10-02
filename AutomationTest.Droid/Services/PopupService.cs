using Android.App;
using Android.Widget;
using AutomationTest.Core.Services;
using MvvmCross.Platforms.Android;
using System;
using System.Threading.Tasks;

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

        public Task<DateTimeOffset> ShowDatePicker(DateTimeOffset date)
        {
            var tcs = new TaskCompletionSource<DateTimeOffset>();

            var dialog = new DatePickerDialog(_activity.Activity, (o, e) =>
            {
                tcs.SetResult(e.Date);
            }, date.Year, date.Month - 1, date.Day);

            dialog.Show();

            return tcs.Task;
        }
    }
}