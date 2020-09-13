using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Class describes examiner model</summary>
    [Table(Name = "Examiners")]
    public class Examiner : IExaminer
    {
        /// <summary>Default constructor</summary>
        public Examiner()
        {
        }

        /// <summary>Creating an instance of <see cref="Examiner"/> via session name, surname and patronymic</summary>
        /// <param name="name">Examiner name</param>
        /// <param name="surname">Examiner surname</param>
        /// <param name="patronymic">Examiner patronymic</param>
        public Examiner(string name, string surname, string patronymic) => (Name, Surname, Patronymic) = (name, surname, patronymic);

        /// <summary>Creating an instance of <see cref="Examiner"/> via session id, name, surname and patronymic</summary>
        /// <param name="id">Examiner id</param>
        /// <param name="name">Examiner name</param>
        /// <param name="surname">Examiner surname</param>
        /// <param name="patronymic">Examiner patronymic</param>
        public Examiner(int id, string name, string surname, string patronymic) => (Id, Name, Surname, Patronymic) = (id, name, surname, patronymic);

        /// <inheritdoc cref="IExaminer.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="IExaminer.Name"/>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <inheritdoc cref="IExaminer.Surname"/>
        [Column(Name = "Surname")]
        public string Surname { get; set; }

        /// <inheritdoc cref="IExaminer.Patronymic"/>
        [Column(Name = "Patronymic")]
        public string Patronymic { get; set; }
    }
}