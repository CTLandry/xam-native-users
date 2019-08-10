using System;
using System.Threading.Tasks;
using xam.native.core.Models;

namespace xam.native.core.Services
{
    public interface IContactsService
    {
        Task AddContact(IContact contact);
    }
}
