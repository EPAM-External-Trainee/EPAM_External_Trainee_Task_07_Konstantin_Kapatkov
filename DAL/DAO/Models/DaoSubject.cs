using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoSubject : IDao<Subject>
    {
        private readonly string _connectionString;

        public DaoSubject(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(Subject data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Subject>().InsertOnSubmit(data); db.SubmitChanges();}).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Subject> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Subject>().FirstOrDefault(s => s.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }     

        public async Task<bool> TryUpdateAsync(Subject data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Subject subject = db.GetTable<Subject>().FirstOrDefault(s => s.Id == data.Id);
                    subject.Name = data.Name;
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
                await Task.Run(() => { db.GetTable<Subject>().DeleteOnSubmit(db.GetTable<Subject>().FirstOrDefault(s => s.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Subject>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Subject>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}