using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace DAL.DAO.Models
{
    public class DaoKnowledgeAssessmentForm : IDao<KnowledgeAssessmentForm>
    {
        private readonly string _connectionString;

        public DaoKnowledgeAssessmentForm(string connectionString) => _connectionString = connectionString;

        public void Create(KnowledgeAssessmentForm data)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<KnowledgeAssessmentForm>().InsertOnSubmit(data);
            db.SubmitChanges();
        }

        public KnowledgeAssessmentForm Read(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<KnowledgeAssessmentForm>().FirstOrDefault(f => f.Id == id);
        }   
        
        public void Update(KnowledgeAssessmentForm data)
        {
            using DataContext db = new DataContext(_connectionString);
            KnowledgeAssessmentForm form = db.GetTable<KnowledgeAssessmentForm>().FirstOrDefault(f => f.Id == data.Id);

            if (form != null)
            {
                form.Form = data.Form;
                db.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using DataContext db = new DataContext(_connectionString);
            db.GetTable<KnowledgeAssessmentForm>().DeleteOnSubmit(db.GetTable<KnowledgeAssessmentForm>().FirstOrDefault(f => f.Id == id));
            db.SubmitChanges();
        }

        public IEnumerable<KnowledgeAssessmentForm> ReadAll()
        {
            using DataContext db = new DataContext(_connectionString);
            return db.GetTable<KnowledgeAssessmentForm>().ToList();
        }
    }
}