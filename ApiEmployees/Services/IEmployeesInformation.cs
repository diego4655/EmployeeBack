using ApiEmployees.Entities;

namespace ApiEmployees.Services
{
    public interface IEmployeesInformation
    {
        Task<ServiceResponse> GetAllEmployeesInformation();

        Task<ServiceResponse> GetEmployeeInformation(int employee_id);
    }
}