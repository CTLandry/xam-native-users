using System.Collections.Generic;
using System.Threading.Tasks;

namespace xam.native.core.Repositories.LocalRepository
{
    public interface ILocalRepository<T>
    {
        Task<IList<T>> GetAll(T ModelType);
        Task<T> Get(T Model);
        Task<int> Save(T Model);
    }
}
