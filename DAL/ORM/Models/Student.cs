using ResultsOfTheSession.DAL.ORM.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    /// <summary>Class describes student model</summary>
    [Table(Name = "Students")]
    public class Student : IStudent
    {
        /// <summary>Default constructor</summary>
        public Student()
        {
        }

        /// <summary>Creating an instance of <see cref="Student"/> via name, surname, patronymic, gender id, birthday, group id</summary>
        /// <param name="name">Student name</param>
        /// <param name="surname">Student surname</param>
        /// <param name="patronymic">Student patronymic</param>
        /// <param name="genderId">Student gender id</param>
        /// <param name="birthday">Student birthday</param>
        /// <param name="groupId">Studnet group id</param>
        public Student(string name, string surname, string patronymic, int genderId, DateTime birthday, int groupId) => (Name, Surname, Patronymic, GenderId, Birthday, GroupId) = (name, surname, patronymic, genderId, birthday, groupId);

        /// <summary>Creating an instance of <see cref="Student"/> via id, name, surname, patronymic, gender id, birthday and group id</summary>
        /// <param name="id">Student id</param>
        /// <param name="name">Student name</param>
        /// <param name="surname">Student surname</param>
        /// <param name="patronymic">Student patronymic</param>
        /// <param name="genderId">Student gender id</param>
        /// <param name="birthday">Student birthday</param>
        /// <param name="groupId">Studnet group id</param>
        public Student(int id, string name, string surname, string patronymic, int genderId, DateTime birthday, int groupId) => (Id, Name, Surname, Patronymic, GenderId, Birthday, GroupId) = (id, name, surname, patronymic, genderId, birthday, groupId);

        /// <inheritdoc cref="IStudent.Id"/>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <inheritdoc cref="IStudent.Name"/>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <inheritdoc cref="IStudent.Surname"/>
        [Column(Name = "Surname")]
        public string Surname { get; set; }

        /// <inheritdoc cref="IStudent.Patronymic"/>
        [Column(Name = "Patronymic")]
        public string Patronymic { get; set; }

        /// <inheritdoc cref="IStudent.Birthday"/>
        [Column(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        /// <inheritdoc cref="IStudent.GenderId"/>
        [Column(Name = "GenderId")]
        public int GenderId { get; set; }

        /// <inheritdoc cref="IStudent.GroupId"/>
        [Column(Name = "GroupId")]
        public int GroupId { get; set; }
    }
}