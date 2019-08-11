using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using xam.native.core.Helpers;
using xam.native.core.Models;
using xam.native.core.Repositories.LocalRepository;
using xam.native.core.ViewModels;
using xam.native.localdatabase;

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

                Mvx.IoCProvider.ConstructAndRegisterSingleton<ISQLiteDatabase<ContactModel> , GenericSQLiteDatabase<ContactModel>>();


                RegisterAppStart<SplashViewModel>();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
            }
        }
    }
}
