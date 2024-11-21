using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext _context;

        internal DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual T GetById(object id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Insert(T entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Insert: " + ex.Message);
            }
        }

        public void Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update: " + ex.Message);
            }
        }

        public virtual void Delete(object id)
        {
            try
            {
                T entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete: " + ex.Message);
            }
        }
        public virtual void Delete(T entityToDelete)
        {
            try
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }

                dbSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete: " + ex.Message);
            }
        }
        public void SaveChange()
        {
            using IDbContextTransaction dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                throw new Exception("Error SaveChange: " + ex.Message);
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> queryable = dbSet;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (includeProperties != null)
            {
                string[] array = includeProperties.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            if (orderBy != null)
            {
                queryable = orderBy(queryable);
            }

            return queryable.ToList();
        }
    }
}
