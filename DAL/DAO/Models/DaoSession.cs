using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoSession : IDao<Session>
    {
        private readonly string _connectionString;

        public DaoSession(string connectionString) => _connectionString = connectionString;

        public void Create(Session data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Session>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public Session Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Session>().FirstOrDefault(s => s.Id == id);
        }

        public void Update(Session data)
        {
            using DataContext db = new DataContext(_connectionString);
            Session session = db.GetTable<Session>().FirstOrDefault(s => s.Id == data.Id);

            if (session != null)
            {
                session = data;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Session>().DeleteOnSubmit(db.GetTable<Session>().FirstOrDefault(s => s.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<Session> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Session>().ToList();
        }
    }
}