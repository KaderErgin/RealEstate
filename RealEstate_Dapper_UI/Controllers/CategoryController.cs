﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController   (IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44333/api/Categories");//listele
            if (responseMessage.IsSuccessStatusCode)//islem basariliysa
            {
                var jsonData = await
                responseMessage.Content.ReadAsStringAsync();//gelen icerigi string formatinda oku
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);//json formatında veriyi oku tablo(metin) formatına donustur
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);//ekle
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");//string dondulecekler (icerigin kendisi,turu(tr destekli),medya tur)
            var responseMessage = await client.PostAsync("https://localhost:44333/api/Categories",stringContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44333/api/Categories/{id}");
            if(responseMessage.IsSuccessStatusCode)//200 donerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();//ornek alındı
            var responseMessage = await client.GetAsync($"https://localhost:44333/api/Categories/{id}");    
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44333/api/Categories/",stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
