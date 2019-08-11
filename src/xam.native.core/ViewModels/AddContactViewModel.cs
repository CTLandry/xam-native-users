using System;
using MvvmCross.ViewModels;
using xam.native.core.Models;

namespace xam.native.core.ViewModels
{
    public class AddContactViewModel : MvxViewModel<IContact, IContact>
    {
        private IContact newContact;

        public AddContactViewModel()
        {
        }

        public override void Prepare(IContact parameter)
        {
            this.newContact = parameter;
        }
    }
}
