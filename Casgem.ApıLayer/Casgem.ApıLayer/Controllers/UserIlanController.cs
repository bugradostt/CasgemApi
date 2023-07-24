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
        public async Task<IActionResult> AddIlan(Ilanlar p)
        {
            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");

            //Ilanlar documentToAdd = new Ilanlar
            //{
            //    IlanAdi = "John Doe",
            //    BinaYasi = 30,

            //};

            collection.InsertOne(p);
            return Ok(p);
        }





    }
}
