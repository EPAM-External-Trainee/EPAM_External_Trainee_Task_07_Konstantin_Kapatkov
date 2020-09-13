using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    /// <summary>Class describes CRUD functionality for <see cref="Gender"/> model</summary>
    public class DaoGender : IDao<Gender>
    {
        /// <summary>SQL Server connection string</summary>
        private readonly string _connectionString;

        /// <summary>Creating an instance of <see cref="DaoGender"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoGender(string connectionString) => _connectionString = connectionString;

        /// <inheritdoc cref="IDao{T}.TryCreateAsync(T)"/>
        public async Task<bool> TryCreateAsync(Gender data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Gender>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAsync(int)"/>
        public async Task<Gender> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Gender>().FirstOrDefault(g => g.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryUpdateAsync(T)"/>
        public async Task<bool> TryUpdateAsync(Gender data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Gender gender = db.GetTable<Gender>().FirstOrDefault(g => g.Id == data.Id);
                    gender.GenderType = data.GenderType;
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
                await Task.Run(() => { db.GetTable<Gender>().DeleteOnSubmit(db.GetTable<Gender>().FirstOrDefault(g => g.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAllAsync"/>
        public async Task<IEnumerable<Gender>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Gender>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}