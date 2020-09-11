using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    public class DaoGroup : IDao<Group>
    {
        private readonly string _connectionString;

        public DaoGroup(string connectionString) => _connectionString = connectionString;

        public async Task<bool> TryCreateAsync(Group data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() => { db.GetTable<Group>().InsertOnSubmit(data); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Group> TryReadAsync(int id)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Group>().FirstOrDefault(g => g.Id == id)).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryUpdateAsync(Group data)
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                await Task.Run(() =>
                {
                    Group group = db.GetTable<Group>().FirstOrDefault(g => g.Id == data.Id);
                    group.Name = data.Name;
                    group.GroupSpecialtyId = data.GroupSpecialtyId;
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
                await Task.Run(() => { db.GetTable<Group>().DeleteOnSubmit(db.GetTable<Group>().FirstOrDefault(g => g.Id == id)); db.SubmitChanges(); }).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Group>> TryReadAllAsync()
        {
            try
            {
                using DataContext db = new DataContext(_connectionString);
                return await Task.Run(() => db.GetTable<Group>().ToList()).ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}