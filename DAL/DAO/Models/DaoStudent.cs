﻿using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    /// <summary>Class describes CRUD functionality for <see cref="Student"/> model</summary>
    public class DaoStudent : IDao<Student>
    {
        /// <summary>SQL Server connection string</summary>
        private readonly string _connectionString;

        /// <summary>Creating an instance of <see cref="DaoStudent"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoStudent(string connectionString) => _connectionString = connectionString;

        /// <inheritdoc cref="IDao{T}.TryCreateAsync(T)"/>
        public async Task<bool> TryCreateAsync(Student data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Student>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAsync(int)"/>
        public async Task<Student> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Student>().FirstOrDefault(s => s.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryUpdateAsync(T)"/>
        public async Task<bool> TryUpdateAsync(Student data)
        {
            try
            {
                DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Student student = db.GetTable<Student>().FirstOrDefault(s => s.Id == data.Id);
                    student.Name = data.Name;
                    student.Surname = data.Surname;
                    student.Patronymic = data.Patronymic;
                    student.Birthday = data.Birthday;
                    student.GenderId = data.GenderId;
                    student.GroupId = data.GroupId;
                    db.SubmitChanges();
                }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryDeleteAsync(int)"/>
        public async Task<bool> TryDeleteAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Student>().DeleteOnSubmit(db.GetTable<Student>().FirstOrDefault(s => s.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAllAsync"/>
        public async Task<IEnumerable<Student>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Student>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}