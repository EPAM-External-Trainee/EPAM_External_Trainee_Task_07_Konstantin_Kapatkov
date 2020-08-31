namespace ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo
{
    public interface ISession
    {
        int Id { get; set; }

        string Name { get; set; }

        string AcademicYear { get; set; }
    }
}