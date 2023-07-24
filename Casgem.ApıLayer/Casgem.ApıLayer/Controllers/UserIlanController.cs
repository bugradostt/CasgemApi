using Casgem.DataAccessLayer.Concrete;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Casgem.ApıLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIlanController : ControllerBase
    {
      

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
            //List<Ilanlar> documents = await collection.Find(x => true).ToListAsync();

            var sortBuilder = Builders<Ilanlar>.Sort.Descending(x => x._id);
            var documents = await collection.Find(x => true).Sort(sortBuilder).ToListAsync();

            return Ok(documents);

        

           

        }

        [HttpPost]
        public async Task<IActionResult> AddIlan(Ilanlar p)
        {
            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
            collection.InsertOne(p);
            return Ok(p);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIlanById(string id)
        {
            var objectId = new ObjectId(id);

            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
            var filter = Builders<Ilanlar>.Filter.Eq("_id", objectId);

            var document = await collection.Find(filter).FirstOrDefaultAsync();

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }





    }
}
