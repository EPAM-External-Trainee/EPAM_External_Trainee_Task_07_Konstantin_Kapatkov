using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    [Table(Name = "Sessions")]
    public class Session : ISession
    {
        public Session()
        {
        }

        public Session(string name, string academicYear) => (Name, AcademicYear) = (name, academicYear);

        public Session(int id, string name, string academicYear) => (Id, Name, AcademicYear) = (id, name, academicYear);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "AcademicYear")]
        public string AcademicYear { get; set; }
    }
}