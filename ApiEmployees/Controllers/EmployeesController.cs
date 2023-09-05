using ApiEmployees.Entities;
using ApiEmployees.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiEmployees.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesInformation _employeesInformation;

        public EmployeesController(IEmployeesInformation employeesInformation)
        {
            _employeesInformation = employeesInformation;
        }

        [HttpGet]
        [HttpOptions]
        [Route("AllEmployees")]
        public async Task<ServiceResponse> ObtainAllEmployees()
        {
            try
            {
                ServiceResponse result = await _employeesInformation.GetAllEmployeesInformation();
                return result;
            }
            catch (Exception ex)
            {
                return new()
                {
                    status = "Bad Request",
                    Exception = ex.Message
                };
            }
        }

        [HttpGet]
        [HttpOptions]
        [Route("EmployeeById")]
        public async Task<ServiceResponse> ObtainEmployeeInformation([FromQuery] short id)
        {
            try
            {
                ServiceResponse result = await _employeesInformation.GetEmployeeInformation(id);
                return result;
            }
            catch (Exception ex)
            {
                return new()
                {
                    status = "Bad Request",
                    Exception = ex.Message
                };
            }
        }
    }
}