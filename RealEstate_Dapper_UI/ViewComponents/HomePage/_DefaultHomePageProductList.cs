using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44333/api/Products/GetProductByDealOfTheDayTrueWithCategory");//listele
            if (responseMessage.IsSuccessStatusCode)//islem basariliysa
            {
                var jsonData = await  
                responseMessage.Content.ReadAsStringAsync();//gelen icerigi string formatinda oku
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);//json formatında veriyi oku tablo(metin) formatına donustur
                return View(values);         
            }
            return View();
        }

    }                               
}                                   
                                    