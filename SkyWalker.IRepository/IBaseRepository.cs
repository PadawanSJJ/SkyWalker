using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.IRepository
{
    public interface IBaseRepository<T> where T : class,new()
    {
        Task<bool> CreateAsync(T t);

        Task<bool> EditAsync(T t);

        Task<T> FindAsync(Expression<Func<T, bool>> func);
        Task<bool> DeleteAsync(int id);

        Task<List<T>> QueryAsync();

        Task<T> QueryById(int id);

        Task<List<T>> QueryAsync(Expression<Func<T, bool>> func);

        Task<List<T>> QueryAsync(Expression<Func<T, bool>> func,int page,int size, RefAsync<int> total);

        Task<List<T>> QueryAsync(int page,int size, RefAsync<int> total);
    }
}
