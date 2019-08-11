using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xam.native.core.Models;

namespace xam.native.core.Services
{
    public interface IContactsService
    {
        Task AddContact(ContactModel contact);
        Task<List<ContactModel>> LoadContacts();
    }
}
