using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.Entities.Post;
using WeblogWebApp.ServiceLayer.Interfaces.PostTag;

namespace WeblogWebApp.ServiceLayer.Services.PostTag
{
    public class PostTagService : IPostTagService
    {

        private readonly ApplicationDbContext _db;

        public PostTagService(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<bool> Delete(Tag tag)
        {
            try
            {
                _db.Tags.Remove(tag);
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
                var tag = await GetById(id);
                return await Delete(tag);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _db.Tags.ToListAsync();
        }

        public Task<Tag> GetById(int id)
        {
            return _db.Tags.FirstOrDefaultAsync(t => t.Id == id);
        }
        public List<Tag> GetTagsForSelectList()
        {
            return _db.Tags.ToList().Select(tag => new Tag()
            {
                Id = tag.Id,
                Title = tag.Title
            }).ToList();
        }
        public bool Insert(Tag tag)
        {
            try
            {
                _db.Tags.Add(tag);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public bool Update(Tag tag)
        {
            try
            {
                _db.Tags.Update(tag);
                _db.Entry(tag).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
