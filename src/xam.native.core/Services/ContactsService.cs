using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xam.native.core.Models;
using xam.native.core.Repositories.LocalRepository;

namespace xam.native.core.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ISQLiteDatabase<ContactModel> ContactsRepository;

        public ContactsService(ISQLiteDatabase<ContactModel> ContactsRepository) 
        {
            this.ContactsRepository = ContactsRepository;
        }

        public async Task AddContact(ContactModel contact)
        {
            await ContactsRepository.SaveDataAsync(contact);
        }

        public async Task<List<ContactModel>> LoadContacts()
        {
            return await ContactsRepository.GetAllAsync();
        }
    }
}
