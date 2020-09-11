using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoSessionResult : IDao<SessionResult>
    {
        private readonly string _connectionString;

        public DaoSessionResult(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(SessionResult data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<SessionResult>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<SessionResult> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<SessionResult>().FirstOrDefault(sr => sr.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(SessionResult data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    SessionResult sessionResult = db.GetTable<SessionResult>().FirstOrDefault(sr => sr.Id == data.Id);
                    sessionResult.Assessment = data.Assessment;
                    sessionResult.StudentId = data.StudentId;
                    sessionResult.SubjectId = data.SubjectId;
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
                await Task.Run(() => { db.GetTable<SessionResult>().DeleteOnSubmit(db.GetTable<SessionResult>().FirstOrDefault(sr => sr.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<SessionResult>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<SessionResult>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}