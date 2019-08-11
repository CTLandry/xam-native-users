using System;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace xam.native.core.ViewModels
{
    public class SplashViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService NavigationService;

        public SplashViewModel(IMvxNavigationService navigationService)
        {
            this.NavigationService = navigationService;
            Task.Run(async () => await InitalizeApp());
        }

        private async Task InitalizeApp()
        {
            try
            {
                await Task.Delay(2000); // For Effect
                await NavigationService.Navigate<ContactListViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
