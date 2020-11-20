using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoRepoTest
{
    public class MongoRepository<T> where T:AuditEntity
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

    }
}
