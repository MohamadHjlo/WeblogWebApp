using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.Entities.Role.Enum;
using WeblogWebApp.ServiceLayer.Interfaces.User;

namespace WeblogWebApp.ServiceLayer.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Delete(Entities.User.User user)
        {
            try
            {
                var oldUser = await GetById(user.Id);
                _db.Entry(user).State = EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var oldUser = await GetById(id);
                _db.Users.Remove(oldUser);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<List<Entities.User.User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<Entities.User.User> GetById(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public bool Insert(Entities.User.User user)
        {
            try
            {
                _db.Users.Add(user);
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

        public bool Update(Entities.User.User user)
        {
            try
            {
                _db.Entry(user).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<Entities.User.User> GetUserByUserName(string userName)
        {
            return await _db.Users.Where(i => i.UserName == userName).SingleOrDefaultAsync();
        }


        public async Task<Entities.User.User> GetUserByMobile(string mobile)
        {
            return await _db.Users.Where(i => i.Mobile == mobile).FirstOrDefaultAsync();
        }

        public bool IsUserExist(string mobile)
        {
            return _db.Users.Any(i => i.Mobile == mobile);
        }

        public bool IsUserNameExist(string userName)
        {
            return _db.Users.Any(i => i.UserName == userName);
        }

        public async Task<int> GetUserIdByMobile(string mobile)
        {
            Task<int> t = new Task<int>(() =>
            {
                return _db
                    .Users
                    .Where(i => i.Mobile == mobile)
                    .Select(i => i.Id)
                    .SingleOrDefault();
            });
            t.Start();
            return await t;
        }

        public async Task<List<Entities.User.User>> GetDuplicatedUserByMobile(string mobile)
        {
            return await _db.Users.Where(i => i.Mobile == mobile).ToListAsync();
        }


        public async Task<List<Entities.User.User>> GetLatestUsers(int count = 5)
        {
            return await _db.Users.Take(count).ToListAsync();
        }

        public List<Entities.User.User> GetAuthorsForSelectList()
        {
            return _db.Users.Where(user => user.Role.RoleType == RoleType.Author)
                .Select(user => new Entities.User.User()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                }).ToList();
        }


    }
}
