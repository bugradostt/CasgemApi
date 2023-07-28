using Amazon.Runtime;
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

        [HttpPut]
        public async Task<IActionResult> UpdateIlan(Ilanlar p)
        {
            var objectId = new ObjectId(p._id.ToString());

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
