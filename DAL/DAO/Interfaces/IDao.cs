using System.Collections.Generic;

namespace DAL.DAO.Interfaces
{
    public interface IDao<T>
    {
        void Create(T data);

        T Read(int id);

        void Update(T data);

        void Delete(int id);

        IEnumerable<T> ReadAll();
    }
}