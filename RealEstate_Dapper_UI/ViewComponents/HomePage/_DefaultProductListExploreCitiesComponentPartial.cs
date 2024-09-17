using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreCitiesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44333/api/PopularLocations");//Listele
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
