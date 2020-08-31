﻿using ResultsOfTheSession.DAL.ORM.Interfaces;

namespace DAL.ORM.Models
{
    public class Examiner : IExaminer
    {
        public Examiner(string name, string surname, string patronymic) => (Name, Surname, Patronymic) = (name, surname, patronymic);

        public Examiner(int id, string name, string surname, string patronymic) => (Id, Name, Surname, Patronymic) = (id, name, surname, patronymic);

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public override bool Equals(object obj) => obj is Examiner examiner && Id == examiner.Id && Name == examiner.Name && Surname == examiner.Surname && Patronymic == examiner.Patronymic;

        public override int GetHashCode()
        {
            int hashCode = 1987267599;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Surname.GetHashCode();
            hashCode = hashCode * -1521134295 + Patronymic.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"Examiner name: {Name}, surname: {Surname}, patronymic: {Patronymic}.";
    }
}