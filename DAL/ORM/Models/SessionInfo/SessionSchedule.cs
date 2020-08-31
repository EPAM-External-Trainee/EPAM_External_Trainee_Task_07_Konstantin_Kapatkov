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

        public override bool Equals(object obj) => obj is SessionSchedule schedule && Id == schedule.Id && SessionId == schedule.SessionId && GroupId == schedule.GroupId && SubjectId == schedule.SubjectId && Date == schedule.Date && KnowledgeAssessmentFormId == schedule.KnowledgeAssessmentFormId && ExaminerId == schedule.ExaminerId;

        public override int GetHashCode()
        {
            int hashCode = -1658479756;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionId.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + KnowledgeAssessmentFormId.GetHashCode();
            hashCode = hashCode * -1521134295 + ExaminerId.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Session schedule id: {Id}, session id {SessionId}, group id: {GroupId}, subject id: {SubjectId}, date: {Date.ToShortDateString()}, knowledge assessment form id: {KnowledgeAssessmentFormId}, examiner id: {ExaminerId}";
    }
}