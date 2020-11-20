using MongoDB.Driver;
using System;

namespace mongoRepoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = new MongoUrl("mongodb://localhost:27017");
            var client = new MongoClient(url);
            var database = client.GetDatabase("local");
            var collection = database.GetCollection<TestObject>("Collection1");
            var document = new TestObject { Id = Guid.NewGuid(), Name = "McGyver", FirstName = "Angus1" };
            collection.InsertOne(document);

            var firstdocument = collection.Find(d => d.FirstName == "Angus1").FirstOrDefault();
            Console.WriteLine(firstdocument?.Name);
        }
    }
}
