using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoGroup : IDao<Group>
    {
        private readonly string _connectionString;

        public DaoGroup(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;") => _connectionString = connectionString;

        public void Create(Group data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Group>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public Group Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Group>().FirstOrDefault(g => g.Id == id);
        }

        public void Update(Group data)
        {
            using DataContext db = new DataContext(_connectionString);
            Group group = db.GetTable<Group>().FirstOrDefault(g => g.Id == data.Id);

            if (group != null)
            {
                group = data;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<Group>().DeleteOnSubmit(db.GetTable<Group>().FirstOrDefault(g => g.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<Group> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<Group>().ToList();
        }
    }
}