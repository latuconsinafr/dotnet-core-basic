using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dotnet_basic.Data;
using dotnet_basic.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_basic.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext context;
        private readonly DbSet<T> dbSet;
        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetById(id) == null)
                    throw new NullReferenceException();
            } 
        }

        public async Task Remove(Guid id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete == null)
                throw new NullReferenceException();

            dbSet.Remove(entityToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<int> CountAll()
        {
            return await dbSet.CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.CountAsync(predicate);
        }
    }
}