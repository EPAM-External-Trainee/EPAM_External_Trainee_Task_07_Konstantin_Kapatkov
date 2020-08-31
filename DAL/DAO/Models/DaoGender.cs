using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoGender : IDao<Gender>
    {
        private readonly string _connectionString;

        public DaoGender(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;") => _connectionString = connectionString;

        public void Create(Gender data)
        {
            using (DataContext db = new DataContext(_connectionString))
            {
                db.GetTable<Gender>().InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Gender Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Gender data)
        {
            throw new NotImplementedException();
        }
    }
}
