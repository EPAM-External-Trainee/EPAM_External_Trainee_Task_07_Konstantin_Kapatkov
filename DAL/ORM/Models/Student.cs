using ResultsOfTheSession.DAL.ORM.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "Students")]
    public class Student : IStudent
    {
        public Student() { }

        public Student(string name, string surname, string patronymic, int genderId, DateTime birthday, int groupId) => (Name, Surname, Patronymic, GenderId, Birthday, GroupId) = (name, surname, patronymic, genderId, birthday, groupId);

        public Student(int id, string name, string surname, string patronymic, int genderId, DateTime birthday, int groupId) => (Id, Name, Surname, Patronymic, GenderId, Birthday, GroupId) = (id, name, surname, patronymic, genderId, birthday, groupId);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Surname")]
        public string Surname { get; set; }

        [Column(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Column(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Column(Name = "GenderId")]
        public int GenderId { get; set; }

        [Column(Name = "GroupId")]
        public int GroupId { get; set; }
    }
}