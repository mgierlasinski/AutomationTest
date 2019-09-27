using AutomationTest.Core.ViewModels;
using MvvmCross.ViewModels;

namespace AutomationTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MenuViewModel>();
        }
    }
}
