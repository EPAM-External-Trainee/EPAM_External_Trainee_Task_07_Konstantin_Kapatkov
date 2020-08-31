using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "GroupSpecialties")]
    public class GroupSpecialty : IGroupSpecialty
    {
        public GroupSpecialty() { }

        public GroupSpecialty(string name) => Name = name;

        public GroupSpecialty(int id, string name) => (Id, Name) = (id, name);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column(Name = "Name")]
        public string Name { get; set; }

        public override bool Equals(object obj) => obj is GroupSpecialty specialty && Id == specialty.Id && Name == specialty.Name;

        public override int GetHashCode()
        {
            int hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Group specialty id: {Id}, name: {Name}.";
    }
}