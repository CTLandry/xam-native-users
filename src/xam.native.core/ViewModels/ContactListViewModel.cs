using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using xam.native.core.Helpers;
using xam.native.core.Models;
using xam.native.core.Services;

namespace xam.native.core.ViewModels
{
    public class ContactListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService NavigationService;
        private readonly IContactsService ContactService;

        private MvxObservableCollection<IContact> contacts;
        public MvxObservableCollection<IContact> PropertyContacts
        {
            get { return contacts; }
            set { SetProperty(ref contacts, value); }
        }

        public ContactListViewModel(IMvxNavigationService NavigationService,
                                    IContactsService ContactService)
        {
            this.NavigationService = NavigationService;
            this.ContactService = ContactService;


        }

        public override async Task Initialize()
        {
            await base.Initialize();

            if (PropertyContacts == null)
                await LoadContacts();
        }

        private async Task LoadContacts()
        {
            try
            {
                PropertyContacts = new MvxObservableCollection<IContact>(await ContactService.LoadContacts());
            }
            catch (SystemException ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
            }

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

                var newlyAddedContact = await NavigationService.Navigate<AddContactViewModel, IContact, ContactModel>
                                               (new ContactModel());

                if (newlyAddedContact != null)
                {
                    await ContactService.AddContact(newlyAddedContact);
                    await LoadContacts();
                }
                   
            }
            catch (Exception ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
            }
        }



    }
}
