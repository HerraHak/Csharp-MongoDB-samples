using MongoDB.Driver;
using System;

namespace mongoRepoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new MongoRepository<TestObject>();
            var document = new TestObject { Id = Guid.NewGuid(), Name = "McGyver", FirstName = "Angus1" };
            repo.Insert(document).GetAwaiter().GetResult();

            var firstdocument = repo.Find(d => d.FirstName.Contains("Angus")).GetAwaiter().GetResult();
            foreach(var doc in firstdocument)
            {
                Console.WriteLine(doc.Name);
            }

            var alldocs = repo.GetAll().GetAwaiter().GetResult();
            foreach(var doc in alldocs)
            {
                Console.WriteLine($"{doc.Name}, {doc.FirstName}, {doc.Id}");
            }
        }
    }
}
