using MvvmCross.IoC;
using MvvmCross.ViewModels;
using xam.native.core.ViewModels;
using System;
using MvvmCross.Navigation;
using xam.native.core.Helpers;

namespace xam.native.core
{
    public class App : MvxApplication
    {
        public App()
        {
            try
            {
              CreatableTypes()
             .EndingWith("Service")
             .AsInterfaces()
             .RegisterAsLazySingleton();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
            }
        }
    }
}
