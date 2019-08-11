using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using xam.native.core.Helpers;
using xam.native.core.Models;

namespace xam.native.core.ViewModels
{
    public class AddContactViewModel : MvxViewModel<ContactModel, ContactModel>
    {
        private ContactModel Contact;
        public ContactModel PropertyContact
        {
            get { return Contact; }
            set { SetProperty(ref Contact, value); }
        }

        private string _error;
        public string PropertyError
        {
            get { return _error; }
            set { SetProperty(ref _error, value); }
        }

        private readonly IMvxNavigationService NavigationService;

        public AddContactViewModel(IMvxNavigationService NavigationService)
        {
            this.NavigationService = NavigationService;
        }

        public override void Prepare(ContactModel parameter)
        {
            this.Contact = parameter;
        }

        private async Task<bool> ValidateInput(ContactModel NewContact)
        {

            if(!await Validations.NotNull(NewContact))
            {
                PropertyError = "New contact is null!";
                return false;
            }

            if (!await Validations.NotNull(NewContact.Name))
            {
                PropertyError = "New contact must have a name.";
                return false;
            }

            if(!await Validations.NotNull(NewContact.Password))
            {
                PropertyError = "Password cannot be empty.";
                return false;
            }

            if (!await Validations.CheckLength((NewContact.Password)))
            {
                PropertyError = "Password must be between 5 and 12 characters.";
                return false;
            }


            if (!await Validations.InclusionAndExclusionRulesCheck(NewContact.Password))
            {
                PropertyError = "Password must be a mixture of letters and numbers with at least one of each.";
                return false;
            }


            if (await Validations.CheckRepeatedSequence(NewContact.Password))
            {
                PropertyError = "Password cannot have repeating sequences";
                return false;
            }



            return true;
        }

        private ICommand saveContactCommand;
        public ICommand SaveContactCommand
        {
            get
            {
                saveContactCommand = saveContactCommand ?? new MvxCommand(async () => await SaveNewContact());
                return saveContactCommand;
            }
        }

        public async Task SaveNewContact()
        {
            if (await ValidateInput(PropertyContact))
                await NavigationService.Close(this, PropertyContact);
        }
    }
}
