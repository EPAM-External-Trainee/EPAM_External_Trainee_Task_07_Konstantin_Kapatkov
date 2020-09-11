using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoGender : IDao<Gender>
    {
        private readonly string _connectionString;

        public DaoGender(string connectionString) => _connectionString = connectionString;

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