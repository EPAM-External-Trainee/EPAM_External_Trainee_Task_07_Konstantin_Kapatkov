using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;

namespace DAL.ORM.Models.SessionInfo
{
    public class SessionResult : ISessionResult
    {
        public SessionResult(int subjectId, int studentId, string assessment, int sessionId) => (SubjectId, StudentId, Assessment, SessionId) = (subjectId, studentId, assessment, sessionId);

        public SessionResult(int id, int subjectId, int studentId, string assessment, int sessionId) => (Id, SubjectId, StudentId, Assessment, SessionId) = (id, subjectId, studentId, assessment, sessionId);

        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public string Assessment { get; set; }

        public int SessionId { get; set ; }

        public override bool Equals(object obj) => obj is SessionResult result && Id == result.Id && SubjectId == result.SubjectId && StudentId == result.StudentId && Assessment == result.Assessment && SessionId == result.SessionId;

        public override int GetHashCode()
        {
            int hashCode = -1844385664;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + Assessment.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionId.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Sessin result id: {Id}, subject id: {SubjectId}, student id: {StudentId}, assesment: {Assessment}, session id : {SessionId}";
    }
}