using AutomationTest.Core.ViewModels;
using AutomationTest.Data.Repositories;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace AutomationTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IPackageRepository, PackageRepository>();

            RegisterAppStart<RootViewModel>();
        }
    }
}
