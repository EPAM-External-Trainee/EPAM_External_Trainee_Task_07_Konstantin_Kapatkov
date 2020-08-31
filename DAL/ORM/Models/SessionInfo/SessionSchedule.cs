using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    [Table(Name = "SessionSchedules")]
    public class SessionSchedule : ISessionSchedule
    {
        public SessionSchedule() { }

        public SessionSchedule(int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId, int examinerId) => (SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId, ExaminerId) = (sessionId, groupId, subjectId, date, knowledgeAssessmentFormId, examinerId);

        public SessionSchedule(int id, int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId, int examinerId) => (Id, SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId, ExaminerId) = (id, sessionId, groupId, subjectId, date, knowledgeAssessmentFormId, examinerId);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "SessionId")]
        public int SessionId { get; set; }

        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        [Column(Name = "KnowledgeAssessmentFormId")]
        public int KnowledgeAssessmentFormId { get; set; }

        [Column(Name = "ExaminerId")]
        public int ExaminerId { get; set; }
    }
}