using Casgem.DataAccessLayer.Concrete;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Casgem.ApıLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIlanController : ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> ListIlan()
        //{
        //    // MongoDB bağlantı adresi ve diğer ayarlar
        //    string connectionString = "mongodb://localhost:27017";
        //    MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));

        //    // MongoClient oluşturma
        //    MongoClient mongoClient = new MongoClient(settings);

        //    // Veritabanına bağlanma
        //    IMongoDatabase database = mongoClient.GetDatabase("CasgemEmlakApiDb"); // myDatabase yerine kendi veritabanı adınızı kullanın



        //    //...

        //    IMongoCollection<Ilanlar> collection = database.GetCollection<Ilanlar>("Ilanlar"); // myCollection yerine kendi koleksiyon adınızı kullanın

        //    List<Ilanlar> documents = await collection.Find(x => true).ToListAsync();

        //    return Ok(documents);
  
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddIlan()
        //{
        //    string connectionString = "mongodb://localhost:27017";
        //    MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));

        //    // MongoClient oluşturma
        //    MongoClient mongoClient = new MongoClient(settings);

        //    // Veritabanına bağlanma
        //    IMongoDatabase database = mongoClient.GetDatabase("CasgemEmlakApiDb"); // myDatabase yerine kendi veritabanı adınızı kullanın


        //    IMongoCollection<Ilanlar> collection = database.GetCollection<Ilanlar>("Ilanlar"); // myCollection yerine kendi koleksiyon adınızı kullanın

        //    Ilanlar documentToAdd = new Ilanlar
        //    {
        //        IlanAdi = "John Doe",
        //        BinaYasi = 30,
        //        // Diğer özellikleri de doldurabilirsiniz...
        //    };

        //    collection.InsertOne(documentToAdd);
        //    return Ok(documentToAdd);
        //}



        private readonly MongoDbManager _mongoDbManager;

        public UserIlanController()
        {
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "CasgemEmlakApiDb";
            _mongoDbManager = MongoDbManager.GetInstance(connectionString, databaseName);
        }

        //...

        [HttpGet]
        public async Task<IActionResult> ListIlan()
        {
            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
            List<Ilanlar> documents = await collection.Find(x => true).ToListAsync();

            return Ok(documents);
        }

        [HttpPost]
        public async Task<IActionResult> AddIlan()
        {
            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");

            Ilanlar documentToAdd = new Ilanlar
            {
                IlanAdi = "John Doe",
                BinaYasi = 30,

            };

            collection.InsertOne(documentToAdd);
            return Ok(documentToAdd);
        }





    }
}
