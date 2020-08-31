using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    [Table(Name = "Sessions")]
    public class Session : ISession
    {
        public Session() { }

        public Session(string name, string academicYear) => (Name, AcademicYear) = (name, academicYear);

        public Session(int id, string name, string academicYear) => (Id, Name, AcademicYear) = (id, name, academicYear);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "AcademicYear")]
        public string AcademicYear { get; set; }

        public override bool Equals(object obj) => obj is Session session && Id == session.Id && Name == session.Name && AcademicYear == session.AcademicYear;

        public override int GetHashCode()
        {
            int hashCode = -963778851;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            hashCode = hashCode * -1521134295 + AcademicYear.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{Name}, academic year: {AcademicYear}";
    }
}