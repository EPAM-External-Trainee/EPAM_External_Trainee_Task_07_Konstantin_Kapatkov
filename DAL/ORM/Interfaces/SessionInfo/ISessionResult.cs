namespace ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo
{
    public interface ISessionResult
    {
        int Id { get; set; }

        int SubjectId { get; set; }

        int StudentId { get; set; }

        string Assessment { get; set; }

        int SessionId { get; set; }
    }
}