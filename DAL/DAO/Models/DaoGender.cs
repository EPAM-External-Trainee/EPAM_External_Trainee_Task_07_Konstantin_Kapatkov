using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoGender : IDao<Gender>
    {
        private readonly string _connectionString;

        public DaoGender(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;") => _connectionString = connectionString;

        public void Create(Gender data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Gender>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public Gender Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Gender>().FirstOrDefault(g => g.Id == id);
        }

        public void Update(Gender data)
        {
            using DataContext db = new DataContext(_connectionString);
            Gender gender = db.GetTable<Gender>().FirstOrDefault(g => g.Id == data.Id);

            if (gender != null)
            {
                gender.GenderType = data.GenderType;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Gender>().DeleteOnSubmit(db.GetTable<Gender>().FirstOrDefault(g => g.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<Gender> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Gender>().ToList();
        }
    }
}