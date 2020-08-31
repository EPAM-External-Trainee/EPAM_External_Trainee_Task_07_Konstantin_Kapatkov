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

        public override bool Equals(object obj) => obj is Subject subject && Id == subject.Id && Name == subject.Name;

        public override int GetHashCode()
        {
            int hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Subject id: {Id}, subject name: {Name}.";
    }
}