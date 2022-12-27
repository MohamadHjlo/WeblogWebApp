namespace WeblogWebApp.ServiceLayer.Interfaces.Role
{
    public  interface IRoleService : IBaseService<Entities.Role.Role>
    {
        Task<List<int>> GetAllRolesId();
    }
}
