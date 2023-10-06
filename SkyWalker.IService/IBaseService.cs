using SqlSugar;
using System.Linq.Expressions;

namespace SkyWalker.IService
{
    public interface IBaseService<T> where T : class,new()
    {
        Task<bool> CreateAsync(T t);

        Task<bool> EditAsync(T t);

        Task<bool> DeleteAsync(int id);

        Task<List<T>> QueryAsync();

        Task<T> QueryById(int id);

        Task<List<T>> QueryAsync(Expression<Func<T, bool>> func);

        Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total);

        Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total);
    }
}