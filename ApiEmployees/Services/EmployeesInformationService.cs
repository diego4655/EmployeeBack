using ApiEmployees.Entities;
using ApiEmployees.Repository;
using ApiEmployees.Util;
using Newtonsoft.Json;

namespace ApiEmployees.Services
{
    public class EmployeesInformationService : IEmployeesInformation
    {
        private readonly IDataAccess<ServiceResponse> _dataAccess;

        public EmployeesInformationService(IDataAccess<ServiceResponse> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<ServiceResponse> GetAllEmployeesInformation()
        {
            try
            {
                ServiceResponse dataAccessResponse = await _dataAccess.GetAll();
                if (dataAccessResponse.status == EnvironmentVariables.SuccessStatus)
                {
                    string data = JsonConvert.SerializeObject(dataAccessResponse.Data);
                    List<Employee> listOfEmployees = JsonConvert.DeserializeObject<Employee[]>(data).ToList();
                    listOfEmployees.ForEach(data => data.employee_anual_salary = CalculateEmployeeSalary(data.employee_salary));
                    return new()
                    {
                        status = EnvironmentVariables.SuccessStatus,
                        Data = JsonConvert.SerializeObject(listOfEmployees)
                    };
                }
                return new()
                {
                    status = EnvironmentVariables.FailedStatus,
                    Exception = dataAccessResponse.Message
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se genero una excepcion en el servicio GetAllEmployeesInformation {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResponse> GetEmployeeInformation(int employee_id)
        {
            try
            {
                ServiceResponse dataAccessResponse = await _dataAccess.Get(employee_id);

                if (dataAccessResponse.status == EnvironmentVariables.SuccessStatus)
                {
                    string data = JsonConvert.SerializeObject(dataAccessResponse.Data);
                    Employee employee = JsonConvert.DeserializeObject<Employee>(data);
                    employee.employee_anual_salary = CalculateEmployeeSalary(employee.employee_salary);
                    return new()
                    {
                        status = EnvironmentVariables.SuccessStatus,
                        Data = JsonConvert.SerializeObject(employee)
                    };
                }
                return new()
                {
                    status = EnvironmentVariables.FailedStatus,
                    Exception = dataAccessResponse.Message
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se genero una excepcion en el servicio GetEmployeeInformation {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private int? CalculateEmployeeSalary(int employee_salary)
        {
            int employee_annual_salary = employee_salary * 12;
            return employee_annual_salary;
        }
    }
}