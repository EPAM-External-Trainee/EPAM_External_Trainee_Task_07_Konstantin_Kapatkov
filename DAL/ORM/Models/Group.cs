using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Class describes group model</summary>
    [Table(Name = "Groups")]
    public class Group : IGroup
    {
        /// <summary>Default constructor</summary>
        public Group()
        {
        }

        /// <summary>Creating an instance of <see cref="Group"/> via name and group specialty id</summary>
        /// <param name="name">Group name</param>
        /// <param name="groupSpecialtyId">Group specialty id</param>
        public Group(string name, int groupSpecialtyId) => (Name, GroupSpecialtyId) = (name, groupSpecialtyId);

        /// <summary>Creating an instance of <see cref="Group"/> via id, name and group specialty id</summary>
        /// <param name="id">Group id</param>
        /// <param name="name">Group name</param>
        /// <param name="groupSpecialtyId">Group specialty id</param>
        public Group(int id, string name, int groupSpecialtyId) => (Id, Name, GroupSpecialtyId) = (id, name, groupSpecialtyId);

        /// <inheritdoc cref="IGroup.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="IGroup.Name"/>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <inheritdoc cref="IGroup.GroupSpecialtyId"/>
        [Column(Name = "GroupSpecialtyId")]
        public int GroupSpecialtyId { get; set; }
    }
}