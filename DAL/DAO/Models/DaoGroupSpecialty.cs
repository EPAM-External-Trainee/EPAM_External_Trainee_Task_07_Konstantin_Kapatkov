using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoGroupSpecialty : IDao<GroupSpecialty>
    {
        private readonly string _connectionString;

        public DaoGroupSpecialty(string connectionString) => _connectionString = connectionString;

        public void Create(GroupSpecialty data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<GroupSpecialty>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public GroupSpecialty Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<GroupSpecialty>().FirstOrDefault(gs => gs.Id == id);
        }

        public void Update(GroupSpecialty data)
        {
            using DataContext db = new DataContext(_connectionString);
            GroupSpecialty groupSpecialty = db.GetTable<GroupSpecialty>().FirstOrDefault(gs => gs.Id == data.Id);

            if (groupSpecialty != null)
            {
                groupSpecialty = data;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<GroupSpecialty>().DeleteOnSubmit(db.GetTable<GroupSpecialty>().FirstOrDefault(gs => gs.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<GroupSpecialty> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<GroupSpecialty>().ToList();
        }
    }
}