using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "KnowledgeAssessmentForms")]
    public class KnowledgeAssessmentForm : IKnowledgeAssessmentForm
    {
        public KnowledgeAssessmentForm() { }

        public KnowledgeAssessmentForm(string form) => Form = form;

        public KnowledgeAssessmentForm(int id, string form) => (Id, Form) = (id, form);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Form")]
        public string Form { get; set; }
    }
}