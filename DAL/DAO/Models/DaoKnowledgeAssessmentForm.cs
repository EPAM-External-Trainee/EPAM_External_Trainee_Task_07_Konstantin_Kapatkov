using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoKnowledgeAssessmentForm : IDao<KnowledgeAssessmentForm>
    {
        private readonly string _connectionString;

        public DaoKnowledgeAssessmentForm(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(KnowledgeAssessmentForm data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<KnowledgeAssessmentForm>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<KnowledgeAssessmentForm> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<KnowledgeAssessmentForm>().FirstOrDefault(f => f.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(KnowledgeAssessmentForm data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    KnowledgeAssessmentForm form = db.GetTable<KnowledgeAssessmentForm>().FirstOrDefault(f => f.Id == data.Id);
                    form.Form = data.Form;
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
                await Task.Run(() => { db.GetTable<KnowledgeAssessmentForm>().DeleteOnSubmit(db.GetTable<KnowledgeAssessmentForm>().FirstOrDefault(f => f.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<KnowledgeAssessmentForm>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<KnowledgeAssessmentForm>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}