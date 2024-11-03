using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategory();
        Task CreateCategory(CreateCategoryDto categorydto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto categorydto);
        Task<GetByIDCategoryDto> GetCategory(int id);// girilen id degeri dondur geri
    }
}
