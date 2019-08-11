using System;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace xam.native.core.Repositories.LocalRepository
{
    public class SQLiteDatabase : ISQLiteDatabase
    {
        private readonly string localDatabasePath =
            Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "XamNativeRepository.db3");

        private static SQLiteAsyncConnection database;

        public SQLiteDatabase()
        {
            if (database == null)
            {
                database = new SQLiteAsyncConnection(localDatabasePath);
            }
        }

        public async Task<SQLiteAsyncConnection> GetDatabaseConnection()
        {
            return await Task.Run(() =>
            {
                return database;
            });
            
        }
    }
}
