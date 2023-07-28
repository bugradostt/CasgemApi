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
    public class UserController : ControllerBase
    {
        private readonly MongoDbManager _mongoDbManager;

        public UserController()
        {
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "CasgemEmlakApiDb";
            _mongoDbManager = MongoDbManager.GetInstance(connectionString, databaseName);
        }

        [HttpGet]
        public async Task<IActionResult> ListUser()
        {
            IMongoCollection<User> collection = _mongoDbManager.Database.GetCollection<User>("User");
            var sortBuilder = Builders<User>.Sort.Descending(x => x._id);
            var documents = await collection.Find(x => true).Sort(sortBuilder).ToListAsync();

            return Ok(documents);

        }


        [HttpPost]
        public async Task<IActionResult> AddUser(User p)
        {
           
            IMongoCollection<User> collection = _mongoDbManager.Database.GetCollection<User>("User");
            collection.InsertOne(p);
            return Ok(p);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var objectId = new ObjectId(id);

            IMongoCollection<User> collection = _mongoDbManager.Database.GetCollection<User>("User");
            var filter = Builders<User>.Filter.Eq("_id", objectId);

            var document = await collection.Find(filter).FirstOrDefaultAsync();

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var objectId = new ObjectId(id);

            IMongoCollection<User> collection = _mongoDbManager.Database.GetCollection<User>("User");
            var filter = Builders<User>.Filter.Eq("_id", objectId);

            collection.DeleteOne(filter);

            return Ok("Silindi");
        }


    }
}
