using MvvmCross.IoC;
using MvvmCross.ViewModels;
using xam.native.core.Helpers;
using xam.native.core.ViewModels;

namespace xam.native.core
{
    public class App : MvxApplication
    {
        /// <summary>
        /// App Entry Point. Start app and register DI via MVVMCross.
        /// </summary>
        public App()
        {
            try
            {
              CreatableTypes()
             .EndingWith("Service")
             .AsInterfaces()
             .RegisterAsLazySingleton();

              RegisterAppStart<ContactListViewModel>();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
            }
        }
    }
}
