namespace WeblogWebApp.ServiceLayer.Interfaces.PostMedia
{
    public interface IPostMediaService : IBaseService<Entities.Post.PostMedia>
    {
        Task<List<Entities.Post.PostMedia>> GetPostMediaByPostId(int id);
    }
}
