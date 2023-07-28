using CasgemApiConsume.Dtos.CategoryDtos;
using CasgemApiConsume.Dtos.IlanlarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CasgemApiConsume.Controllers
{
    public class IlanlarController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public IlanlarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> ListIlan()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44332/api/UserIlan");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultIlanlarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ListIlanById(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44332/api/UserIlan/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdIlanlarDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddIlan()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddIlan(CreateIlanDto p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44332/api/UserIlan", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListIlan");

            }

            return View();
        }


        public async Task<IActionResult> Ilanlarim()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44332/api/UserIlan");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultIlanlarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

       
        public async Task<IActionResult> DeleteIlan(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44332/api/UserIlan/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Ilanlarim");

            }
            return RedirectToAction("Ilanlarim");
        }



        [HttpGet]
        public async Task<IActionResult> EditIlan(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44332/api/UserIlan/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EditIlanDto>(jsonData);
                return View(values);
            }
            return View();

        }

        [HttpPost]
   
        public async Task<IActionResult> EditIlan( EditIlanDto p)
        {
            string id = "64c0b808ad6880881a38fb9a";
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(p);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44332/api/UserIlan/{id}", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                // Güncelleme başarılı
                return RedirectToAction("ListIlan"); 
            }

            return View();
        }





    }
}
