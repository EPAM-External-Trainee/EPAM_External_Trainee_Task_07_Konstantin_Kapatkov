using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoExaminer : IDao<Examiner>
    {
        private readonly string _connectionString;

        public DaoExaminer(string connectionString) => _connectionString = connectionString;

        public void Create(Examiner data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Examiner>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public Examiner Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Examiner>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(Examiner data)
        {
            using DataContext db = new DataContext(_connectionString);
            Examiner examiner = db.GetTable<Examiner>().FirstOrDefault(e=> e.Id == data.Id);

            if (examiner != null)
            {
                examiner.Name = data.Name;
                examiner.Surname = data.Surname;
                examiner.Patronymic = data.Patronymic;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Examiner>().DeleteOnSubmit(db.GetTable<Examiner>().FirstOrDefault(e => e.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<Examiner> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Examiner>().ToList();
        }
    }
}