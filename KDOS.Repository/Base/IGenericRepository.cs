using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Repository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetById(object Id); 
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        void SaveChange();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
