using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Interface describes subject model</summary>
    [Table(Name = "Subjects")]
    public class Subject : ISubject
    {
        /// <summary>Default constructor</summary>
        public Subject()
        {
        }

        /// <summary>Creating an instance of <see cref="Subject"/> via name</summary>
        /// <param name="name">Subject name</param>
        public Subject(string name) => Name = name;

        /// <summary>Creating an instance of <see cref="Subject"/> via name</summary>
        /// <param name="id">Subject id</param>
        /// <param name="name">Subject name</param>
        public Subject(int id, string name) => (Id, Name) = (id, name);

        /// <inheritdoc cref="ISubject.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="ISubject.Name"/>
        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}