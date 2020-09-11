using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoExaminer : IDao<Examiner>
    {
        private readonly string _connectionString;

        public DaoExaminer(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(Examiner data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Examiner>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Examiner> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Examiner>().FirstOrDefault(e => e.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(Examiner data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Examiner examiner = db.GetTable<Examiner>().FirstOrDefault(e => e.Id == data.Id);
                    examiner.Name = data.Name;
                    examiner.Surname = data.Surname;
                    examiner.Patronymic = data.Patronymic;
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
                await Task.Run(() => { db.GetTable<Examiner>().DeleteOnSubmit(db.GetTable<Examiner>().FirstOrDefault(e => e.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IEnumerable<Examiner>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Examiner>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}