using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using xam.native.core.Helpers;
using xam.native.core.Models;
using xam.native.core.Repositories.LocalRepository;

namespace xam.native.core.ViewModels
{
    public class ContactListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService NavigationService;
        private readonly ILocalRepository<ContactModel> LocalRepository;

        private MvxObservableCollection<IContact> contacts;
        public MvxObservableCollection<IContact> PropertyContacts
        {
            get { return contacts; }
            set { SetProperty(ref contacts, value); }
        }

        public ContactListViewModel(IMvxNavigationService NavigationService,
                                    ILocalRepository<ContactModel> LocalRepository)
        {
            this.NavigationService = NavigationService;
            this.LocalRepository = LocalRepository;

            PropertyContacts = new MvxObservableCollection<IContact>();
        }

        private ICommand addContactCommand;
        public ICommand AddContactCommand
        {
            get
            {
                addContactCommand = addContactCommand ?? new MvxCommand(async () => await AddNewUser());
                return addContactCommand;
            }
        }

        private async Task AddNewUser()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
            }
        }



    }
}
