using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using xam.native.core.Models;

namespace xam.native.core.Repositories.LocalRepository
{
    public class GenericSQLiteDatabase<T> : ISQLiteDatabase<T> where T : IModel, new()
    {

        /// <summary>
        /// Should be a config setting but for demo purposes.
        /// </summary>
        private readonly string localDatabasePath =
            Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "XamNativeRepository.db3");

        private SQLiteAsyncConnection database;

        public GenericSQLiteDatabase()
        {
            database = new SQLiteAsyncConnection(localDatabasePath);
            database.CreateTableAsync<ContactModel>().Wait();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await database.Table<T>().ToListAsync();
        }

        public async Task<T> GetItemAsync(string PrimaryKey)
        {
            return await database.Table<T>()
            .Where(i => i.GetModelPrimaryKey() == PrimaryKey)
            .FirstAsync();
        }

        public async Task SaveDataAsync(T instance)
        {
            if (instance.GetModelPrimaryKey() != null)
            {
                 await database.UpdateAsync(instance);
            }
            else
            {
                 await database.InsertAsync(instance);
            }
        }
    }
}
