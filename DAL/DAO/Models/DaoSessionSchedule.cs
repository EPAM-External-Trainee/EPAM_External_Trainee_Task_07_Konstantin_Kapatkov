using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoSessionSchedule : IDao<SessionSchedule>
    {
        private readonly string _connectionString;

        public DaoSessionSchedule(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;") => _connectionString = connectionString;

        public void Create(SessionSchedule data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<SessionSchedule>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public SessionSchedule Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<SessionSchedule>().FirstOrDefault(ss => ss.Id == id);
        }

        public void Update(SessionSchedule data)
        {
            using DataContext db = new DataContext(_connectionString);
            SessionSchedule sessionSchedule = db.GetTable<SessionSchedule>().FirstOrDefault(ss => ss.Id == data.Id);

            if (sessionSchedule != null)
            {
                sessionSchedule = data;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<SessionSchedule>().DeleteOnSubmit(db.GetTable<SessionSchedule>().FirstOrDefault(ss => ss.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<SessionSchedule> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<SessionSchedule>().ToList();
        }
    }
}