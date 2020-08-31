using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "Groups")]
    public class Group : IGroup
    {
        public Group() { }

        public Group(string name, int groupSpecialtyId) => (Name, GroupSpecialtyId) = (name, groupSpecialtyId);

        public Group(int id, string name, int groupSpecialtyId) => (Id, Name, GroupSpecialtyId) = (id, name, groupSpecialtyId);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "GroupSpecialtyId")]
        public int GroupSpecialtyId { get; set; }
    }
}