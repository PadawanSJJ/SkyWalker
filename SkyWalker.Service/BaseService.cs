using SkyWalker.IRepository;
using SkyWalker.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
                _baseRepository = baseRepository;
        }
        public async Task<bool> CreateAsync(T t)
        {
            return await _baseRepository.CreateAsync(t);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<bool> EditAsync(T t)
        {
            return await _baseRepository.EditAsync(t);
        }

        public async Task<List<T>> QueryAsync()
        {
            return await _baseRepository.QueryAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
        {
           return await _baseRepository.QueryAsync(func);
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _baseRepository.QueryAsync(func,page,size,total);
        }

        public async Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await _baseRepository.QueryAsync(page,size,total);
        }

        public async Task<T> QueryById(int id)
        {
            return await _baseRepository.QueryById(id);
        }
    }
}
