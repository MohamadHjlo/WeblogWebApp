using WeblogWebApp.Models.Post;
using IndexViewModel = WeblogWebApp.Models.PostCategory.IndexViewModel;

namespace WeblogWebApp.ServiceLayer.Interfaces.PostCategory
{
    public interface IPostCategoryService : IBaseService<Entities.Post.PostCategory>
    {

        List<Entities.Post.PostCategory> GetCategoriesForSelectList();

        List<IndexViewModel> GetAllWithParents();

    }
}
