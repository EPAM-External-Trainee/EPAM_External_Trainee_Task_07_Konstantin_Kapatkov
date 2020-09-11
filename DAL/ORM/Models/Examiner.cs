using ResultsOfTheSession.DAL.ORM.Interfaces;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "Examiners")]
    public class Examiner : IExaminer
    {
        public Examiner()
        {
        }

        public Examiner(string name, string surname, string patronymic) => (Name, Surname, Patronymic) = (name, surname, patronymic);

        public Examiner(int id, string name, string surname, string patronymic) => (Id, Name, Surname, Patronymic) = (id, name, surname, patronymic);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Surname")]
        public string Surname { get; set; }

        [Column(Name = "Patronymic")]
        public string Patronymic { get; set; }
    }
}