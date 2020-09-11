using DAL.DAO.Interfaces;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoSessionSchedule : IDao<SessionSchedule>
    {
        private readonly string _connectionString;

        public DaoSessionSchedule(string connectionString) => _connectionString = connectionString;

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