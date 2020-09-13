using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    /// <summary>Class describes session schedule model</summary>
    [Table(Name = "SessionSchedules")]
    public class SessionSchedule : ISessionSchedule
    {
        /// <summary>Default constructor</summary>
        public SessionSchedule()
        {
        }

        /// <summary>Creating an instance of <see cref="SessionSchedule"/> via session id, group id, date, knowledge assessment form id and examiner id</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <param name="subjectId">Subject id</param>
        /// <param name="date">Date of exam or credit</param>
        /// <param name="knowledgeAssessmentFormId">Knowledge assessment form id</param>
        /// <param name="examinerId">Examiner id</param>
        public SessionSchedule(int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId, int examinerId) => (SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId, ExaminerId) = (sessionId, groupId, subjectId, date, knowledgeAssessmentFormId, examinerId);

        /// <summary>Creating an instance of <see cref="SessionSchedule"/> via id, session id, group id, date, knowledge assessment form id and examiner id</summary>
        /// <param name="id">Session schedule id</param>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <param name="subjectId">Subject id</param>
        /// <param name="date">Date of exam or credit</param>
        /// <param name="knowledgeAssessmentFormId">Knowledge assessment form id</param>
        /// <param name="examinerId">Examiner id</param>
        public SessionSchedule(int id, int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId, int examinerId) => (Id, SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId, ExaminerId) = (id, sessionId, groupId, subjectId, date, knowledgeAssessmentFormId, examinerId);

        /// <inheritdoc cref="ISessionSchedule.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="ISessionSchedule.SessionId"/>
        [Column(Name = "SessionId")]
        public int SessionId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.GroupId"/>
        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.SubjectId"/>
        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.Date"/>
        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        /// <inheritdoc cref="ISessionSchedule.KnowledgeAssessmentFormId"/>
        [Column(Name = "KnowledgeAssessmentFormId")]
        public int KnowledgeAssessmentFormId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.ExaminerId"/>
        [Column(Name = "ExaminerId")]
        public int ExaminerId { get; set; }
    }
}