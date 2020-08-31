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

        public override bool Equals(object obj) => obj is KnowledgeAssessmentForm form && Id == form.Id && Form == form.Form;

        public override int GetHashCode()
        {
            int hashCode = 1043838055;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Form.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Knowledge assessment form id: {Id}, form: {Form}.";
    }
}