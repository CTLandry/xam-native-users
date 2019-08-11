using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using xam.native.core.Helpers;
using xam.native.core.Models;

namespace xam.native.core.Repositories.LocalRepository
{
    public class ContactsRepository : ILocalRepository<ContactModel>
    {
        private readonly SQLiteAsyncConnection Connection;
        private readonly ISQLiteDatabase Database;

        public ContactsRepository(ISQLiteDatabase Database)
        {
            this.Database = Database;
            this.Connection = Task.Run(async () => await Database.GetDatabaseConnection()).Result;
            this.Connection.CreateTableAsync<ContactModel>();
        }

        public async Task<ContactModel> Get(ContactModel Model)
        {
            try
            {
                var contactfound = await Connection.QueryAsync<ContactModel>("SELECT * FROM Contacts WHERE ContactID = ?", Model.ContactID);
                return contactfound[0] ?? null;
            }
            catch (SQLite.SQLiteException ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
                return null;
            }
        }

        public async Task<IList<ContactModel>> GetAll(ContactModel ModelType)
        {
            try
            {
                return await Connection.QueryAsync<ContactModel>("SELECT * FROM Contacts");
            }
            catch (SQLite.SQLiteException ex)
            {
                ErrorHandler.OutPutErrorToConsole(ex);
                return null;
            }
        }

        public async Task<int> Save(ContactModel Model)
        {
            try
            {
                var exists = await Get(Model);

                if (exists != null)
                {
                    return await Connection.UpdateAsync(Model);
                }
                else
                {
                    return await Connection.InsertAsync(Model);
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                var message = ex.Message;
                return 0;
            }
        }
    }
}
