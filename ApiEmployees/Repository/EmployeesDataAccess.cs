using ApiEmployees.Entities;
using ApiEmployees.Util;
using Newtonsoft.Json;
using RestSharp;

namespace ApiEmployees.Repository
{
    internal struct Complements
    {
        public string employeeComplement { get { return "api/v1/employee/"; } }
        public string employeesComplement { get { return "api/v1/employees"; } }
    }

    public class EmployeesDataAccess : IDataAccess<ServiceResponse>
    {
        private readonly Complements _complements;

        public async Task<ServiceResponse> Get(int id)
        {
            try
            {
                string completeComplement = string.Concat(_complements.employeeComplement, id.ToString());
                RestClientOptions options = new RestClientOptions(EnvironmentVariables.EmployeesUrl);
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest(completeComplement, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                ServiceResponse serviceResponse = JsonConvert.DeserializeObject<ServiceResponse>(response.Content) ?? new();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion presentada consumiendo el servicio GetAll {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResponse> GetAll()
        {
            try
            {
                RestClientOptions options = new RestClientOptions(EnvironmentVariables.EmployeesUrl);
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest(_complements.employeesComplement, Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                ServiceResponse serviceResponse = JsonConvert.DeserializeObject<ServiceResponse>(response.Content) ?? new();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception presentada consumiendo el servicio Get {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}