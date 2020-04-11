using Microsoft.EntityFrameworkCore;
using QueuingSystem.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystem.DAL
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        QueuingSystemContext context = ContextManager.GetContext();

        public async Task<T> GetItem(int id)
        {
            var model = await context.Set<T>().FindAsync(id);
            return model;
        }

        // gets list of items async
        public async Task<IEnumerable<T>> GetItems()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }


        public async Task<int> AddItem(T item)
        {
            context.Set<T>().Add(item);
            return await context.SaveChangesAsync();
        }

        // updates an entity in a set
        public async Task<int> UpdateItem(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        // removes an entity in a set
        public async Task<T> RemoveItem(int id)
        {
            var query = await context.Set<T>().FindAsync(id);
            if (query != null)
            {
                context.Set<T>().Remove(query);
                await context.SaveChangesAsync();
            }
            return query;
        }


        public void Dispose()
        {
            context.Dispose();
        }

    }
}
