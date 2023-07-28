using Casgem.DataAccessLayer.Concrete;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Casgem.ApıLayer.Dto.Login;

namespace Casgem.ApıLayer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly MongoDbManager _mongoDbManager;

		public LoginController()
		{
			string connectionString = "mongodb://localhost:27017";
			string databaseName = "CasgemEmlakApiDb";
			_mongoDbManager = MongoDbManager.GetInstance(connectionString, databaseName);
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginDto p)
		{
			IMongoCollection<User> collection = _mongoDbManager.Database.GetCollection<User>("User");

			var existingUser = collection.Find(x => x.UserName == p.UserName && x.UserPassword == p.UserPassword).FirstOrDefault();

			if (existingUser != null)
			{
				return Ok("Giriş başarılı.");
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre yanlış.");
			}
		}







	}
}
