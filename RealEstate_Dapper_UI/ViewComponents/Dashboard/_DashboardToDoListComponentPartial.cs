using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardToDoListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44333/api/ToDoLists");//listele
            if (responseMessage.IsSuccessStatusCode)//islem basariliysa
            {
                var jsonData = await
                responseMessage.Content.ReadAsStringAsync();//gelen icerigi string formatinda oku
                var values = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);//json formatında veriyi oku tablo(metin) formatına donustur
                return View(values);
            }
            return View();
        }
    }
}
