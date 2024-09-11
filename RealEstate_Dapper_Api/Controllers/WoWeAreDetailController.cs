﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

        public WoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
        {
            _whoWeAreDetailRepository = whoWeAreDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreDetailRepository.GetAllWhoWeAreAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            _whoWeAreDetailRepository.CreateWeWhoAreDetail(createWhoWeAreDetailDto);
            return Ok("Hakkımızda Kısmı Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)//disaridan id degeri alacak
        {
            _whoWeAreDetailRepository.DeleteWeWhoAreDetail(id);
            return Ok("Hakkımızda Kısmı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWeWhoAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _whoWeAreDetailRepository.UpdateWeWhoAreDetail(updateWhoWeAreDetailDto);
            return Ok("Hakkımzda Kısmı güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeWhoAreDetail(int id)
        {
            var value = await _whoWeAreDetailRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}