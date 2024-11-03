using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationde();
        Task CreatePopularLocation(CreatePopularLocationDto PopularLocationDto);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDto PopularLocationDto);
        Task<GetByIDPopularLocationDto> GetPopularLocation(int id); 
    }
}
