using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoSessionResult : IDao<SessionResult>
    {
        private readonly string _connectionString;

        public DaoSessionResult(string connectionString) => _connectionString = connectionString;

        public void Create(SessionResult data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<SessionResult>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public SessionResult Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<SessionResult>().FirstOrDefault(sr => sr.Id == id);
        }

        public void Update(SessionResult data)
        {
            using DataContext db = new DataContext(_connectionString);
            SessionResult sessionResult = db.GetTable<SessionResult>().FirstOrDefault(sr => sr.Id == data.Id);

            if (sessionResult != null)
            {
                sessionResult = data;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<SessionResult>().DeleteOnSubmit(db.GetTable<SessionResult>().FirstOrDefault(sr => sr.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<SessionResult> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<SessionResult>().ToList();
        }
    }
}