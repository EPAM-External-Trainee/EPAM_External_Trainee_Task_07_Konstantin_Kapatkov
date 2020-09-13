using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    /// <summary>Class describes CRUD functionality for <see cref="SessionSchedule"/> model</summary>
    public class DaoSessionSchedule : IDao<SessionSchedule>
    {
        /// <summary>SQL Server connection string</summary>
        private readonly string _connectionString;

        /// <summary>Creating an instance of <see cref="DaoSessionResult"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoSessionSchedule(string connectionString) => _connectionString = connectionString;

        /// <inheritdoc cref="IDao{T}.TryCreateAsync(T)"/>
        public async Task<bool> TryCreateAsync(SessionSchedule data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<SessionSchedule>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAsync(int)"/>
        public async Task<SessionSchedule> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<SessionSchedule>().FirstOrDefault(ss => ss.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryUpdateAsync(T)"/>
        public async Task<bool> TryUpdateAsync(SessionSchedule data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    SessionSchedule sessionSchedule = db.GetTable<SessionSchedule>().FirstOrDefault(ss => ss.Id == data.Id);
                    sessionSchedule.SessionId = data.SessionId;
                    sessionSchedule.SubjectId = data.SubjectId;
                    sessionSchedule.KnowledgeAssessmentFormId = data.KnowledgeAssessmentFormId;
                    sessionSchedule.GroupId = data.GroupId;
                    sessionSchedule.ExaminerId = data.ExaminerId;
                    sessionSchedule.Date = data.Date;
                    db.SubmitChanges();
                }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryDeleteAsync(int)"/>
        public async Task<bool> TryDeleteAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<SessionSchedule>().DeleteOnSubmit(db.GetTable<SessionSchedule>().FirstOrDefault(ss => ss.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAllAsync"/>
        public async Task<IEnumerable<SessionSchedule>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<SessionSchedule>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}