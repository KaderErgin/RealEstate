using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        //Kategori Ekle
        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("categoryName",categoryDto.CategoryName);
            parameters.Add("categoryStatus", true);
            using (var connection = _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
        //Kategori Sil
        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("categoryID", id);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        //Kategori listele
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection=_context.CreateConnection())
            {
                var value=await  connection.QueryAsync<ResultCategoryDto>(query);
                return value.ToList();
            }
        }
        //Kategori guncelle
        public async void UpdateCategory(UpdateCategoryDto categorydto)
        {
           string query="Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where " +
                "CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",categorydto.CategoryName);
            parameters.Add("categoryStatus",categorydto.CategoryStatus);
            parameters.Add("categoryID", categorydto.CategoryID);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
