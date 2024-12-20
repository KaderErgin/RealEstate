﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
           _employeeRepository  = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeyList()
        {
            var values = await _employeeRepository.GetAllEmployee();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
           await _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Personel Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)//disaridan id degeri alacak
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok("Personel Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Personel güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);
        }
    }
}
