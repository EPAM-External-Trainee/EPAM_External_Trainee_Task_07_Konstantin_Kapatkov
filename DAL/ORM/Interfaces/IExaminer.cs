namespace ResultsOfTheSession.DAL.ORM.Interfaces
{
    public interface IExaminer
    {
        int Id { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        string Patronymic { get; set; }
    }
}