using ResultsOfTheSession.DAL.ORM.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DAL.ORM.Models
{
    [Table(Name = "Genders")]
    public class Gender : IGender
    {
        public Gender() { }

        public Gender(string gednerType) => GenderType = gednerType;

        public Gender(int id, string gednerType) => (Id, GenderType) = (id, gednerType);

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "GenderType")]
        public string GenderType { get; set; }
    }
}