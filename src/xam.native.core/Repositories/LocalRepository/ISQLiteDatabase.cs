using System;
using System.Threading.Tasks;
using SQLite;

namespace xam.native.core.Repositories.LocalRepository
{
    public interface ISQLiteDatabase
    {
        Task<SQLiteAsyncConnection> GetDatabaseConnection();
    }
}
