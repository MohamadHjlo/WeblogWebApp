using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.ServiceLayer.Interfaces.PostMedia;

namespace WeblogWebApp.ServiceLayer.Services.PostMedia
{
    public class PostMediaService : IPostMediaService
    {

        private readonly ApplicationDbContext _db;

        public PostMediaService(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<bool> Delete(Entities.Post.PostMedia postMedia)
        {
            try
            {
                _db.Entry(postMedia).State = EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var postMedia = await GetById(id);
                return await Delete(postMedia);
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

        public async Task<List<Entities.Post.PostMedia>> GetAll()
        {
            return await _db.PostMedias.AsNoTracking().ToListAsync();
        }

        public Task<Entities.Post.PostMedia> GetById(int id)
        {
            return _db.PostMedias.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Entities.Post.PostMedia>> GetPostMediaByPostId(int id)
        {
            var postMedias = await _db.PostMedias.Where(i=>i.PostId == id).AsNoTracking().ToListAsync();
            return postMedias;
        }

        public bool Insert(Entities.Post.PostMedia postMedia)
        {
            try
            {
                _db.PostMedias.Add(postMedia);
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

        public bool Update(Entities.Post.PostMedia postMedia)
        {
            try
            {
                _db.Entry(postMedia).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
