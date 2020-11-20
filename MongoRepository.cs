using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mongoRepoTest
{
    public class MongoRepository<T> where T:AuditEntity, new()
    {
        private IMongoCollection<T> Collection;
        public MongoRepository()
        {
            var context = new MongoContext();
            Collection = context.Database.GetCollection<T>(nameof(T));
        }

        public async Task Insert(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }        

        public async Task Delete(Guid id)
        {
            await Collection.DeleteOneAsync(e => e.Id == id);
        }

        public async Task BulkInsert(IEnumerable<T> entities)
        {
            await Collection.InsertManyAsync(entities);
        }

        public async Task BulkDelete(IEnumerable<Guid> ids)
        {
            await Collection.DeleteManyAsync(e=>ids.Contains(e.Id));
        }

        public async Task<T> GetById(Guid id)
        {
            return (await Collection.FindAsync(e => e.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> condition)
        {
            return await (await Collection.FindAsync(condition)).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await (await Collection.FindAsync(FilterDefinition<T>.Empty)).ToListAsync();
        }

    }
}
