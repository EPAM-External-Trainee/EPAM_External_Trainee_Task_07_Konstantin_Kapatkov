using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Class describes knowledge assessment form model</summary>
    [Table(Name = "KnowledgeAssessmentForms")]
    public class KnowledgeAssessmentForm : IKnowledgeAssessmentForm
    {
        /// <summary>Default constructor</summary>
        public KnowledgeAssessmentForm()
        {
        }

        /// <summary>Creating an instance of <see cref="KnowledgeAssessmentForm"/> via from name</summary>
        /// <param name="form">Knowledge assessment form name</param>
        public KnowledgeAssessmentForm(string form) => Form = form;

        /// <summary>Creating an instance of <see cref="KnowledgeAssessmentForm"/> via id and from name</summary>
        /// <param name="id">Knowledge assessment form id</param>
        /// <param name="form">Knowledge assessment form name</param>
        public KnowledgeAssessmentForm(int id, string form) => (Id, Form) = (id, form);

        /// <inheritdoc cref=" IKnowledgeAssessmentForm.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref=" IKnowledgeAssessmentForm.Form"/>
        [Column(Name = "Form")]
        public string Form { get; set; }
    }
}