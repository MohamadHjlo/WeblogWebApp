using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.ServiceLayer.Interfaces.Role;

namespace WeblogWebApp.ServiceLayer.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _db;
        public RoleService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Entities.Role.Role>> GetAll()
        {
            return await _db.Roles.ToListAsync();
        }

        public bool Insert(Entities.Role.Role role)
        {
            try
            {
                _db.Roles.Add(role);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Update(Entities.Role.Role role)
        {
            try
            {
                _db.Entry(role).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Delete(Entities.Role.Role role)
        {
            try
            {
                var oldRole = await GetById(role.Id);
                _db.Entry(oldRole).State = EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<Entities.Role.Role> GetById(int id)
        {
            return await _db.Roles.FindAsync(id);
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var oldRole = await GetById(id);
                _db.Roles.Remove(oldRole);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<List<int>> GetAllRolesId()
        {
            return await _db.Roles.Select(i => i.Id).ToListAsync();
        }
    }
}
