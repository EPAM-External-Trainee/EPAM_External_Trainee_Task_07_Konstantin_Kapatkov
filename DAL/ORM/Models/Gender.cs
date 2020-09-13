using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Class describes gender model</summary>
    [Table(Name = "Genders")]
    public class Gender : IGender
    {
        /// <summary>Default constructor</summary>
        public Gender()
        {
        }

        /// <summary>Creating an instance of <see cref="Gender"/> via gender type name</summary>
        /// <param name="gednerType">Gender type name</param>
        public Gender(string gednerType) => GenderType = gednerType;

        /// <summary>Creating an instance of <see cref="Gender"/> via id and gender type name</summary>
        /// <param name="id">Gender id</param>
        /// <param name="gednerType">Gender type name</param>
        public Gender(int id, string gednerType) => (Id, GenderType) = (id, gednerType);

        /// <inheritdoc cref=" IGender.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref=" IGender.GenderType"/>
        [Column(Name = "GenderType")]
        public string GenderType { get; set; }
    }
}