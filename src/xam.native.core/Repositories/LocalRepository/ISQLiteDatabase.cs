using System.Collections.Generic;
using System.Threading.Tasks;
using xam.native.core.Models;

namespace xam.native.core.Repositories.LocalRepository
{
    public interface ISQLiteDatabase<T> 
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetItemAsync(string PrimaryKey);
        Task SaveDataAsync(T instance);
    }
}
