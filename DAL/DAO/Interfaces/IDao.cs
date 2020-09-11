using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DAO.Interfaces
{
    public interface IDao<T>
    {
        Task<bool> TryCreateAsync(T data);

        Task<T> TryReadAsync(int id);

        Task<bool> TryUpdateAsync(T data);

        Task<bool> TryDeleteAsync(int id);

        Task<IEnumerable<T>> TryReadAllAsync();
    }
}