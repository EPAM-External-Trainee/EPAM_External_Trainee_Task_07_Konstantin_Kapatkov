using DAL.DAO.Interfaces;
using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    public class DaoFactory
    {
        private static DaoFactory _instance;
        private static string _connectionString;

        private DaoFactory()
        {
        }

        public static DaoFactory GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DaoFactory();
                _connectionString = connectionString;
            }
            return _instance;
        }

        public IDao<Gender> GetGender() => new DaoGender(_connectionString);

        public IDao<Group> GetGroup() => new DaoGroup(_connectionString);
    }
}