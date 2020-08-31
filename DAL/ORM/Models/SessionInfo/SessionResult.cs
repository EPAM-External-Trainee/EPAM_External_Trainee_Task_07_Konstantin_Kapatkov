using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    [Table(Name = "SessionResults")]
    public class SessionResult : ISessionResult
    {
        public SessionResult() { }

        public SessionResult(int subjectId, int studentId, string assessment, int sessionId) => (SubjectId, StudentId, Assessment, SessionId) = (subjectId, studentId, assessment, sessionId);

        public SessionResult(int id, int subjectId, int studentId, string assessment, int sessionId) => (Id, SubjectId, StudentId, Assessment, SessionId) = (id, subjectId, studentId, assessment, sessionId);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        [Column(Name = "Assessment")]
        public string Assessment { get; set; }

        [Column(Name = "SessionId")]
        public int SessionId { get; set ; }
    }
}