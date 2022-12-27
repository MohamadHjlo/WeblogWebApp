namespace WeblogWebApp.ServiceLayer.Interfaces.User
{
    public interface IUserService : IBaseService<Entities.User.User>
    {
        Task<Entities.User.User> GetUserByUserName(string userName);
        Task<Entities.User.User> GetUserByMobile(string mobile);
        Task<List<Entities.User.User>> GetDuplicatedUserByMobile(string mobile);
        Task<int> GetUserIdByMobile(string mobile);
        bool IsUserExist(string mobile);
        bool IsUserNameExist(string userName);
        Task<List<Entities.User.User>> GetLatestUsers(int count = 5);
        List<Entities.User.User> GetAuthorsForSelectList();

    }
}
