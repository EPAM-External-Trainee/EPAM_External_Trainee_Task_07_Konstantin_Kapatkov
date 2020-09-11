using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoGroupSpecialty : IDao<GroupSpecialty>
    {
        private readonly string _connectionString;

        public DaoGroupSpecialty(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(GroupSpecialty data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<GroupSpecialty>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<GroupSpecialty> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<GroupSpecialty>().FirstOrDefault(gs => gs.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(GroupSpecialty data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    GroupSpecialty groupSpecialty = db.GetTable<GroupSpecialty>().FirstOrDefault(gs => gs.Id == data.Id);
                    groupSpecialty.Name = data.Name;
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
                await Task.Run(() => { db.GetTable<GroupSpecialty>().DeleteOnSubmit(db.GetTable<GroupSpecialty>().FirstOrDefault(gs => gs.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<GroupSpecialty>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<GroupSpecialty>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}