using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.ServiceLayer.Interfaces.Post;

namespace WeblogWebApp.ServiceLayer.Services.Post
{
    public class PostService : IPostService
    {

        private readonly ApplicationDbContext _db;

        public PostService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Entities.Post.Post>> GetAll()
        {
            return await _db.Posts.Include(p => p.PostCategory).ToListAsync();
        }

        public async Task<Entities.Post.Post> GetById(int id)
        {
            return await _db.Posts.Where(t => t.Id == id)
                .Include(p => p.PostCategory)
                .Include(p => p.PostMedias)
                .Include(p => p.PostTags)
                .FirstOrDefaultAsync();
        }

        public bool Insert(Entities.Post.Post post)
        {
            try
            {
                _db.Posts.Add(post);
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

        public bool Update(Entities.Post.Post post)
        {
            try
            {
                _db.Posts.Update(post);
                _db.Entry(post).State = EntityState.Modified;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Entities.Post.Post post)
        {
            try
            {
                _db.Remove(post);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var post = await GetById(id);
                await Delete(post);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool AddPostTags(int postId, int tagId)
        {
            try
            {
                _db.PostTags.Add(new Entities.Post.PostTag()
                {
                    PostId = postId,
                    TagId = tagId
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemovePostTags(int postId)
        {
            try
            {
                await _db.PostTags.Where(postTag => postTag.PostId == postId).ForEachAsync(t => _db.PostTags.Remove(t));
                return true;
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

    }
}
