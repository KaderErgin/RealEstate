using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationdeAsync();
        void CreatePopularLocation(CreatePopularLocationDto PopularLocationDto);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDto PopularLocationDto);
        Task<GetByIDPopularLocationDto> GetPopularLocation(int id); 
    }
}
