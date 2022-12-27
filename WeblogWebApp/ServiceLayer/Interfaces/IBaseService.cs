namespace WeblogWebApp.ServiceLayer.Interfaces
{
    public interface IBaseService<T>:IDisposable
    {
        Task<List<T>>  GetAll();

        Task<T> GetById(int id);
        
        bool Insert(T instance);

        bool Update(T instance);

        Task<bool> Delete(T instance);

        Task<bool> DeleteById(int id);

        Task Save();
        
    }
}