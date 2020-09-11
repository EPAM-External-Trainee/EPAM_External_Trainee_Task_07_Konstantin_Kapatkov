using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "GroupSpecialties")]
    public class GroupSpecialty : IGroupSpecialty
    {
        public GroupSpecialty()
        {
        }

        public GroupSpecialty(string name) => Name = name;

        public GroupSpecialty(int id, string name) => (Id, Name) = (id, name);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}