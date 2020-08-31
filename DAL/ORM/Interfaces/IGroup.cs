namespace ResultsOfTheSession.DAL.ORM.Interfaces
{
    public interface IGroup
    {
        int Id { get; set; }

        string Name { get; set; }

        int GroupSpecialtyId { get; set; }
    }
}