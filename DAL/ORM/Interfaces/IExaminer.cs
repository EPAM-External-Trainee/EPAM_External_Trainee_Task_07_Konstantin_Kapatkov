namespace ResultsOfTheSession.DAL.ORM.Interfaces
{
    /// <summary>Interface describes examiner model</summary>
    public interface IExaminer
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Name</summary>
        string Name { get; set; }

        /// <summary>Surname</summary>
        string Surname { get; set; }

        /// <summary>Patronymic</summary>
        string Patronymic { get; set; }
    }
}