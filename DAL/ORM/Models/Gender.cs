using ResultsOfTheSession.DAL.ORM.Interfaces;

namespace DAL.ORM.Models
{
    public class Gender : IGender
    {
        public Gender(string gednerType) => GenderType = gednerType;

        public Gender(int id, string gednerType) => (Id, GenderType) = (id, gednerType);

        public int Id { get; set; }

        public string GenderType { get; set; }

        public override bool Equals(object obj) => obj is Gender gender && Id == gender.Id && GenderType == gender.GenderType;

        public override int GetHashCode()
        {
            int hashCode = 1714723304;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + GenderType.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Gender id: {Id}, type: {GenderType}.";
    }
}