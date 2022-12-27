using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.Models.Post;
using WeblogWebApp.ServiceLayer.Interfaces.PostCategory;
using IndexViewModel = WeblogWebApp.Models.PostCategory.IndexViewModel;

namespace WeblogWebApp.ServiceLayer.Services.PostCategory
{
    public class PostCategoryService : IPostCategoryService
    {

        private readonly ApplicationDbContext _db;

        public PostCategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<IndexViewModel> GetAllWithParents()
        {
            return _db.PostCategories.Include(p => p.ParentCategory).Include(p => p.SubCategories).ToList().Select(category => new Models.PostCategory.IndexViewModel()
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                ParenetId = category.ParentCategoryId,
                Slug = category.Slug,
                ThumbnailPath = string.IsNullOrWhiteSpace(category.Thunmnail) ? "/Media/PostCategory/default-image.png" : "/Media/PostCategory/Thumb/" + category.Thunmnail,
                Parent = category.ParentCategoryId != null ? new Entities.Post.PostCategory()
                {
                    Id = category.ParentCategory.Id,
                    Title = category.ParentCategory.Title,
                } : null,
                HasChild = category.SubCategories.Any()
            }).AsQueryable().AsNoTracking().ToList();
        }
        public async Task<bool> Delete(Entities.Post.PostCategory? category)
        {
            try
            {
                _db.Remove(category);
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
                var category = await GetById(id);
                await Delete(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Entities.Post.PostCategory> GetCategoriesForSelectList()
        {
            return _db.PostCategories.ToList().Select(c => new Entities.Post.PostCategory()
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }
        public void Dispose()
        {
            _db.Dispose();
        }



        public async Task<Entities.Post.PostCategory?> GetById(int id)
        {
            return await _db.PostCategories.Where(t => t.Id == id).Include(p=>p.SubCategories).FirstOrDefaultAsync();
        }

        public bool Insert(Entities.Post.PostCategory? category)
        {
            try
            {
                _db.PostCategories.Add(category);
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

        public bool Update(Entities.Post.PostCategory? category)
        {
            try
            {
                _db.PostCategories.Update(category);
                _db.Entry(category).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Entities.Post.PostCategory?>> GetAll()
        {
            return await _db.PostCategories.ToListAsync();
        }


    }
}
