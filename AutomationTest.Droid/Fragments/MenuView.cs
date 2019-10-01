using Android.OS;
using Android.Views;
using AutomationTest.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace AutomationTest.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.content_frame, false)]
    public class MenuView : MvxFragment<MenuViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.menu_view, null);
        }
    }
}