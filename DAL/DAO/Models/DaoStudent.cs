using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoStudent : IDao<Student>
    {
        private readonly string _connectionString;

        public DaoStudent(string connectionString) => _connectionString = connectionString;

        public void Create(Student data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Student>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public Student Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Student>().FirstOrDefault(s => s.Id == id);
        }

        public void Update(Student data)
        {
            DataContext db = new DataContext(_connectionString);
            Student student = db.GetTable<Student>().FirstOrDefault(s => s.Id == data.Id);

            if (student != null)
            {
                student.Name = data.Name;
                student.Surname = data.Surname;
                student.Patronymic = data.Patronymic;
                student.Birthday = data.Birthday;
                student.GenderId = data.GenderId;
                student.GroupId = data.GroupId;
                db.SubmitChanges();
                db.Dispose();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Student>().DeleteOnSubmit(db.GetTable<Student>().FirstOrDefault(s => s.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<Student> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Student>().ToList();
        }
    }
}