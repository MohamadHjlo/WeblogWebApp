namespace WeblogWebApp.ServiceLayer.Interfaces.Post
{
    public interface IPostService : IBaseService<Entities.Post.Post>
    {

        bool AddPostTags(int postId, int tagId);

        Task<bool> RemovePostTags(int postId);


    }
}
