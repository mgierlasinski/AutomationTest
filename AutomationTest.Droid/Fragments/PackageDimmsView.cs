using Android.OS;
using Android.Views;
using AutomationTest.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace AutomationTest.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.content_frame, true, 
        Android.Resource.Animation.SlideInLeft, 
        Android.Resource.Animation.SlideOutRight,
        Android.Resource.Animation.SlideInLeft,
        Android.Resource.Animation.SlideOutRight)]
    public class PackageDimmsView : MvxFragment<PackageDimmsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.package_dimms, null);
        }
    }
}