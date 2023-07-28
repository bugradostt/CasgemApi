using Amazon.Runtime;
using Casgem.ApıLayer.Dtos.Ilanlar;
using Casgem.DataAccessLayer.Concrete;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Casgem.ApıLayer.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet("{UserName}")]
        public async Task<IActionResult> UserName(string UserName)
        {
            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");

            var filterBuilder = Builders<Ilanlar>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(UserName))
            {
                filter &= filterBuilder.Regex("UserName", new BsonRegularExpression(UserName, "i")); // "i" parametresi büyük/küçük harf duyarlılığı olmaksızın eşleştirme yapar.
            }

            var values = await collection.Find(filter).ToListAsync();
            //var products = dbContext.Products.Find(filter).ToList();
            return Ok(values);
        }

        [HttpGet("{IlanAdi}")]
		public async Task<IActionResult> Search(string IlanAdi)
		{
			IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");

			var filterBuilder = Builders<Ilanlar>.Filter;
			var filter = filterBuilder.Empty;

			if (!string.IsNullOrEmpty(IlanAdi))
			{
				filter &= filterBuilder.Regex("IlanAdi", new BsonRegularExpression(IlanAdi, "i")); // "i" parametresi büyük/küçük harf duyarlılığı olmaksızın eşleştirme yapar.
			}

            var values = await collection.Find(filter).ToListAsync();   
			//var products = dbContext.Products.Find(filter).ToList();
			return Ok(values);
		}


		[HttpPost]
        public async Task<IActionResult> AddIlan(Ilanlar p)
        {
            p.IlanTarihi = DateTime.Now;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIlan(string id)
        {
            var objectId = new ObjectId(id);

            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
            var filter = Builders<Ilanlar>.Filter.Eq("_id", objectId);

           collection.DeleteOne(filter);
           
            return Ok("Silindi");
        }



        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateIlan(string id, Ilanlar p)
        //{
        //    var objectId = new ObjectId(id);

        //    IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
        //    var value = Builders<Ilanlar>.Filter.Eq("_id", objectId);

        //    var update = Builders<Ilanlar>.Update
        //        .Set(x => x.ImageUrl, p.ImageUrl)
        //        .Set(x => x.IlanAdi, p.IlanAdi)
        //        .Set(x => x.Ucret, p.Ucret)
        //        .Set(x => x.BanyoSayısı, p.BanyoSayısı)
        //        .Set(x => x.BalkonSayısı, p.BalkonSayısı)
        //        .Set(x => x.Kimden, p.Kimden)
        //        .Set(x => x.Takas, p.Takas)
        //        .Set(x => x.Sehir, p.Sehir)
        //        .Set(x => x.Tipi, p.Tipi)
        //        .Set(x => x.Esyali, p.Esyali)
        //        .Set(x => x.KatSayisi, p.KatSayisi)
        //        .Set(x => x.BulunduguKat, p.BulunduguKat)
        //        .Set(x => x.BinaYasi, p.BinaYasi)
        //        .Set(x => x.OdaSayisi, p.OdaSayisi);

        //    var result = await collection.UpdateOneAsync(value, update);
        //    return Ok("Güncellendi");
        //}

        [HttpPut("{_id}")]
        public async Task<IActionResult> UpdateIlan(string _id, Ilanlar p)
        {
            var objectId = new ObjectId(_id.ToString());

            IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
            var value = Builders<Ilanlar>.Filter.Eq("_id", objectId);

            collection.ReplaceOne(x => x._id == objectId, p);


          
            return Ok("Güncellendi");
        }


		[HttpPut]
		public async Task<IActionResult> UpdateIlan1(string id, UpdateIlanDto p)
		{
			var objectId = new ObjectId(id);

			IMongoCollection<Ilanlar> collection = _mongoDbManager.Database.GetCollection<Ilanlar>("Ilanlar");
			var value = Builders<Ilanlar>.Filter.Eq("_id", objectId);

            var update = Builders<Ilanlar>.Update
                .Set(x => x.ImageUrl, p.ImageUrl)
                .Set(x => x.IlanAdi, p.IlanAdi)
                .Set(x => x.Ucret, p.Ucret)
                .Set(x => x.BanyoSayısı, p.BanyoSayısı)
                .Set(x => x.BalkonSayısı, p.BalkonSayısı)
                .Set(x => x.Kimden, p.Kimden)
                .Set(x => x.Takas, p.Takas)
                .Set(x => x.Sehir, p.Sehir)
                .Set(x => x.Tipi, p.Tipi)
                .Set(x => x.Esyali, p.Esyali)
                .Set(x => x.KatSayisi, p.KatSayisi)
                .Set(x => x.BulunduguKat, p.BulunduguKat)
                .Set(x => x.BinaYasi, p.BinaYasi)
                .Set(x => x.OdaSayisi, p.OdaSayisi);

			var result = await collection.UpdateOneAsync(value, update);
			return Ok("Güncellendi");
		}















	}
}
