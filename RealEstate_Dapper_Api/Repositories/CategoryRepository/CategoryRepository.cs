﻿using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
using Microsoft.Identity.Client;

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
        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
        //Kategori Sil
        public async Task DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        //Kategori listele
        public async Task<List<ResultCategoryDto>> GetAllCategory()
        {
            string query = "Select * From Category";
            using (var connection=_context.CreateConnection())
            {
                var value=await  connection.QueryAsync<ResultCategoryDto>(query);
                return value.ToList();
            }
        }
        //Kategorinin id gore getir tum verileri
        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection()) 
            {
                var values = await connection.QueryFirstAsync<GetByIDCategoryDto>(query, parameters);//tek deger dondurecek
                return values;
            }
        }

        //Kategori guncelle
        public async Task UpdateCategory(UpdateCategoryDto categorydto)
        {
           string query="Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where " +
                "CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",categorydto.CategoryName);
            parameters.Add("@categoryStatus",categorydto.CategoryStatus);
            parameters.Add("@categoryID", categorydto.CategoryID);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
