using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoStudent : IDao<Student>
    {
        private readonly string _connectionString;

        public DaoStudent(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(Student data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Student>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Student> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Student>().FirstOrDefault(s => s.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(Student data)
        {
            try
            {
                DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Student student = db.GetTable<Student>().FirstOrDefault(s => s.Id == data.Id);
                    student.Name = data.Name;
                    student.Surname = data.Surname;
                    student.Patronymic = data.Patronymic;
                    student.Birthday = data.Birthday;
                    student.GenderId = data.GenderId;
                    student.GroupId = data.GroupId;
                    db.SubmitChanges();
                }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Student>().DeleteOnSubmit(db.GetTable<Student>().FirstOrDefault(s => s.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Student>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Student>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}