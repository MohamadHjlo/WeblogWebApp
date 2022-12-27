using WeblogWebApp.Entities.Post;

namespace WeblogWebApp.ServiceLayer.Interfaces.PostTag
{
    public interface IPostTagService : IBaseService<Tag>
    {
        List<Tag> GetTagsForSelectList();
    }
}
