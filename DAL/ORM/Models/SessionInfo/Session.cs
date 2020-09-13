using ResultsOfTheSession.DAL.ORM.Interfaces.SessionInfo;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models.SessionInfo
{
    /// <summary>Class describes session model</summary>
    [Table(Name = "Sessions")]
    public class Session : ISession
    {
        /// <summary>Default constructor</summary>
        public Session()
        {
        }

        /// <summary>Creating an instance of <see cref="Session"/> via name and academic year</summary>
        /// <param name="name">Session name</param>
        /// <param name="academicYear">Session academic year</param>
        public Session(string name, string academicYear) => (Name, AcademicYear) = (name, academicYear);

        /// <summary>Creating an instance of <see cref="Session"/> via id, name and academic year</summary>
        /// <param name="id">Session id</param>
        /// <param name="name">Session name</param>
        /// <param name="academicYear">Session academic year</param>
        public Session(int id, string name, string academicYear) => (Id, Name, AcademicYear) = (id, name, academicYear);

        /// <inheritdoc cref="ISession.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="ISession.Name"/>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <inheritdoc cref="ISession.AcademicYear"/>
        [Column(Name = "AcademicYear")]
        public string AcademicYear { get; set; }
    }
}