﻿using Android.App;
using Android.OS;
using AutomationTest.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace AutomationTest.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MenuView : MvxActivity<MenuViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuView);
        }
    }
}