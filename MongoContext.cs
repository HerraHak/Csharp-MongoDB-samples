using MongoDB.Driver;

namespace mongoRepoTest
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; set; }

        public MongoContext()
        {
            var url = new MongoUrl("mongodb://localhost:27017");
            var client = new MongoClient(url);
            Database = client.GetDatabase("local");
        }
    }
}
