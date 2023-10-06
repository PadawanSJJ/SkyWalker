using SkyWalker.IRepository;
using SkyWalker.Models;
using SqlSugar;
using SqlSugar.IOC;
using System.Linq.Expressions;

namespace SkyWalker.Repository
{
    public class BaseRepository<T> :SimpleClient<T>, IBaseRepository<T> where T : class,new()
    {
        public BaseRepository(ISqlSugarClient client=null):base(client)
        {
            base.Context = DbScoped.Sugar;
            base.Context.DbMaintenance.CreateDatabase();
            base.Context.CodeFirst.InitTables<Citizen>();
        }

        public async Task<bool> CreateAsync(T t)
        {
            return await base.InsertAsync(t);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> func)
        {
            return await base.GetFirstAsync(func);

        }

        public async Task<bool> EditAsync(T t)
        {
            return await base.UpdateAsync(t);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<List<T>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size,  RefAsync<int> total)
        {
            return await base.Context.Queryable<T>().Where(func).ToPageListAsync(page, size, total);
        }

        public async Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<T>().ToPageListAsync(page, size ,total);
        }

        public async Task<T> QueryById(int id)
        {
           return await base.GetByIdAsync(id);
        }

    }
}