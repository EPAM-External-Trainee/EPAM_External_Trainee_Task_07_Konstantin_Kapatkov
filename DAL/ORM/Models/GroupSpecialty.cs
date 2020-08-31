using ResultsOfTheSession.DAL.ORM.Interfaces;

namespace DAL.ORM.Models
{
    public class GroupSpecialty : IGroupSpecialty
    {
        public GroupSpecialty(string name) => Name = name;

        public GroupSpecialty(int id, string name) => (Id, Name) = (id, name);

        public int Id { get; set; }

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