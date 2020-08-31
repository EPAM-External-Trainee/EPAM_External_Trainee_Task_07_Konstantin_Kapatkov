using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoSubject : IDao<Subject>
    {
        private readonly string _connectionString;

        public DaoSubject(string connectionString) => _connectionString = connectionString;

        public void Create(Subject data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Subject>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public Subject Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Subject>().FirstOrDefault(s => s.Id == id);
        }     

        public void Update(Subject data)
        {
            using DataContext db = new DataContext(_connectionString);
            Subject subject = db.GetTable<Subject>().FirstOrDefault(s => s.Id == data.Id);

            if (subject != null)
            {
                subject.Name = data.Name;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Subject>().DeleteOnSubmit(db.GetTable<Subject>().FirstOrDefault(s => s.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<Subject> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Subject>().ToList();
        }
    }
}