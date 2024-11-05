using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreCitiesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory,IOptions< ApiSettings> apiSettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("PopularLocations");//Listele

            if (responseMessage.IsSuccessStatusCode)//Islem basariliysa
            {
                var jsonData = await
                responseMessage.Content.ReadAsStringAsync();//Gelen icerigi string formatinda oku
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);//json formatında veriyi oku tablo(metin) formatına donustur
                return View(values);
            }
            return View();
        }
    }
}
