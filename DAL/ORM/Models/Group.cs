using ResultsOfTheSession.DAL.ORM.Interfaces;

namespace DAL.ORM.Models
{
    public class Group : IGroup
    {
        public Group(string name, int groupSpecialtyId) => (Name, GroupSpecialtyId) = (name, groupSpecialtyId);

        public Group(int id, string name, int groupSpecialtyId) => (Id, Name, GroupSpecialtyId) = (id, name, groupSpecialtyId);

        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupSpecialtyId { get; set; }

        public override bool Equals(object obj) => obj is Group group && Id == group.Id && Name == group.Name && GroupSpecialtyId == group.GroupSpecialtyId;

        public override int GetHashCode()
        {
            int hashCode = -1574230485;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupSpecialtyId.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Group id: {Id}, name: {Name}, specialty id: {GroupSpecialtyId}.";
    }
}