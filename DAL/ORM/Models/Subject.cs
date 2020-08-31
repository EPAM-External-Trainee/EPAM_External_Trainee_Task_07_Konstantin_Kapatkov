using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "Subjects")]
    public class Subject : ISubject
    {
        public Subject() { }

        public Subject(string name) => Name = name;

        public Subject(int id, string name) => (Id, Name) = (id, name);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}