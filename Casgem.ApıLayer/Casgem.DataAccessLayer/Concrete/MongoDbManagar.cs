using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Casgem.DataAccessLayer.Concrete
{

    public class MongoDbManager
    {
        private readonly IMongoDatabase _database;

        // Singleton deseni için private constructor
        private MongoDbManager(string connectionString, string databaseName)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(databaseName);
        }

        // Tek örnek için private static instance
        private static MongoDbManager _instance;

        // Singleton deseni için public instance getter metodu
        public static MongoDbManager GetInstance(string connectionString, string databaseName)
        {
            if (_instance == null)
            {
                _instance = new MongoDbManager(connectionString, databaseName);
            }
            return _instance;
        }

        // Veritabanına erişim için public property
        public IMongoDatabase Database => _database;
    }

}
