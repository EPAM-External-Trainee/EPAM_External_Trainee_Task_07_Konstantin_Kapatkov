using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoSession : IDao<Session>
    {
        private readonly string _connectionString;

        public DaoSession(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(Session data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Session>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Session> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Session>().FirstOrDefault(s => s.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(Session data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Session session = db.GetTable<Session>().FirstOrDefault(s => s.Id == data.Id);
                    session.Name = data.Name;
                    session.AcademicYear = data.AcademicYear;
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
                await Task.Run(() =>
                {
                    db.GetTable<Session>().DeleteOnSubmit(db.GetTable<Session>().FirstOrDefault(s => s.Id == id));
                    db.SubmitChanges();
                }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Session>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Session>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}