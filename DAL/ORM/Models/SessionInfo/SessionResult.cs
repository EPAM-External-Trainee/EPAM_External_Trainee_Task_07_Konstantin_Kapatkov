using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    /// <summary>Class describes session result model</summary>
    [Table(Name = "SessionResults")]
    public class SessionResult : ISessionResult
    {
        /// <summary>Default constructor</summary>
        public SessionResult()
        {
        }

        /// <summary>Creating an instance of <see cref="SessionResult"/> via subject id, student id, assessment and session id</summary>
        /// <param name="subjectId">Subject id</param>
        /// <param name="studentId">Student id</param>
        /// <param name="assessment">Assessment</param>
        /// <param name="sessionId">Session id</param>
        public SessionResult(int subjectId, int studentId, string assessment, int sessionId) => (SubjectId, StudentId, Assessment, SessionId) = (subjectId, studentId, assessment, sessionId);

        /// <summary>Creating an instance of <see cref="SessionResult"/> via id, subject id, student id, assessment and session id</summary>
        /// <param name="id">Session result id</param>
        /// <param name="subjectId">Subject id</param>
        /// <param name="studentId">Student id</param>
        /// <param name="assessment">Assessment</param>
        /// <param name="sessionId">Session id</param>
        public SessionResult(int id, int subjectId, int studentId, string assessment, int sessionId) => (Id, SubjectId, StudentId, Assessment, SessionId) = (id, subjectId, studentId, assessment, sessionId);

        /// <inheritdoc cref="ISessionResult.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="ISessionResult.SubjectId"/>
        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        /// <inheritdoc cref="ISessionResult.StudentId"/>
        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        /// <inheritdoc cref="ISessionResult.Assessment"/>
        [Column(Name = "Assessment")]
        public string Assessment { get; set; }

        /// <inheritdoc cref="ISessionResult.SessionId"/>
        [Column(Name = "SessionId")]
        public int SessionId { get; set; }
    }
}