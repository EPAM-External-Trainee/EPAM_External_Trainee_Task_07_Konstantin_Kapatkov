using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Class describes group specialty model</summary>
    [Table(Name = "GroupSpecialties")]
    public class GroupSpecialty : IGroupSpecialty
    {
        /// <summary>Default constructor</summary>
        public GroupSpecialty()
        {
        }

        /// <summary>Creating an instance of <see cref="GroupSpecialty"/> via name</summary>
        /// <param name="name">Group specialty name</param>
        public GroupSpecialty(string name) => Name = name;

        /// <summary>Creating an instance of <see cref="GroupSpecialty"/> via id and name</summary>
        /// <param name="id">Group specialty id</param>
        /// <param name="name">Group specialty name</param>
        public GroupSpecialty(int id, string name) => (Id, Name) = (id, name);

        /// <inheritdoc cref="IGroupSpecialty.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="IGroupSpecialty.Name"/>
        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}